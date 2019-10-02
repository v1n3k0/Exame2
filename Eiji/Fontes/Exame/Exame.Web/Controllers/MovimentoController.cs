using AutoMapper;
using Exame.BO.Interface.Servico;
using Exame.Help.Extensao;
using Exame.VO;
using Exame.VO.Entidade.Procedure;
using Exame.Web.App_Start;
using Exame.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exame.Web.Controllers
{
    public class MovimentoController : Controller
    {
        private readonly IProdutoServico _produtoServico;
        private readonly ICosifServico _cosifServico;
        private readonly IMovimentoServico _movimentoServico;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IMapper _mapper;

        public MovimentoController(IProdutoServico produtoServico, ICosifServico cosifServico, 
            IMovimentoServico movimentoServico)
        {
            _produtoServico = produtoServico;
            _cosifServico = cosifServico;
            _movimentoServico = movimentoServico;
            _mapper = AutoMapperConfig.Mapper;
        }

        [HttpGet]
        public ActionResult Create()
        {
            _logger.Info("Create [INICIO]");

            ListarProduto();

            _logger.Info("Create [FIM]");
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovimentoView movimentoView)
        {
            _logger.Info("Create [INICIO]|movimentoView: {0}", movimentoView.SerializarXML());

            Movimento adicionarMovimentoRequest = 
                _mapper.Map<MovimentoView, Movimento>(movimentoView);

            bool resultado = _movimentoServico.Adicionar(adicionarMovimentoRequest);

            if (resultado)
            {
                _logger.Info($"Create [FIM]|resultado: {resultado}");
            }
            else
            {
                ViewBag.Alerta = "Erro ao cadastrar movimento.";

                ListarProduto();

                _logger.Warn("Create [FIM]|resultado: {0}", resultado);
            }

            return RedirectToAction("Create");
        }

        [HttpGet]
        public PartialViewResult ListarMovimentosProduto()
        {
            _logger.Info("ListarMovimentosProduto [INICIO]");
            IEnumerable<MovimentoProdutoView> movimentosProduto = null;

            ICollection<MovimentoProduto> movimentos = _movimentoServico.ListarMovimentosProduto();

            if(movimentos != null) {
                movimentosProduto = 
                    _mapper.Map<ICollection<MovimentoProduto>, IEnumerable<MovimentoProdutoView>>(movimentos);
            }
            else
            {
                movimentosProduto = Enumerable.Empty<MovimentoProdutoView>();
                ViewBag.Alerta = "Erro ao listar MovimentoProduto.";
                _logger.Warn("ListarMovimentosProduto");
            }

            _logger.Info("ListarMovimentosProduto [FIM]");
            return PartialView(movimentosProduto);
        }

        [HttpGet]
        public JsonResult GetCosifs(int codigoProduto)
        {
            _logger.Info("GetCosifs [INICIO]|codigoProduto: {0}", codigoProduto);

            ICollection<Cosif> cosifs = _cosifServico.ListarAtivoPorProduto(codigoProduto);

            if (cosifs != null)
            {
                var cosifsList = new SelectList(
                    cosifs.Select(x => new
                    {
                        x.Codigo,
                        Descricao = $"{x.Codigo} - ({x.Classificacao})"
                    }),
                    "Codigo",
                    "Descricao"
                    );

                cosifs = null;

                _logger.Info("GetCosifs [FIM]");
                return Json(cosifsList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _logger.Warn("GetCosifs [FIM]");
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

        private void ListarProduto()
        {
            _logger.Info("ListarProduto [INICIO]");

            ICollection<Produto> produtos = _produtoServico.ListarAtivo();

            if (produtos != null)
            {
                ViewBag.Produtos = new SelectList(
                    produtos.OrderBy(x => x.Descricao),
                    "Codigo",
                    "Descricao"
                    );

                produtos = null;
            }
            else
            {
                ViewBag.Alerta = "Erro ao listar produtos.";
                _logger.Warn("ListarProduto");
            }

            _logger.Info("ListarProduto [FIM]");
        }
    }
}