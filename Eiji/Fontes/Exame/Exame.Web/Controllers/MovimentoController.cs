using AutoMapper;
using Exame.VO.Argumento.Cosif;
using Exame.VO.Argumento.Movimento;
using Exame.VO.Argumento.Produto;
using Exame.VO.Interface.Servico;
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

        public MovimentoController(IProdutoServico produtoServico, ICosifServico cosifServico, IMovimentoServico movimentoServico)
        {
            _produtoServico = produtoServico;
            _cosifServico = cosifServico;
            _movimentoServico = movimentoServico;
            _mapper = AutoMapperConfig.Mapper;
        }

        // GET: Movimento
        [HttpGet]
        public ActionResult Index()
        {
            _logger.Info("Index [INICIO]");
            
            IEnumerable<MovimentoProdutoResponse> movimentos = _movimentoServico.ListarMovimentosProduto();                     

            IEnumerable<MovimentoProdutoView> movimentosProduto = _mapper.Map<IEnumerable<MovimentoProdutoResponse>, IEnumerable<MovimentoProdutoView>>(movimentos);

            _logger.Info("Index [FIM]");
            return View(movimentosProduto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            _logger.Info("Create [INICIO]");
            var movimento = new MovimentoView();

            ListarProduto();

            _logger.Info("Create [FIM]");
            return View(movimento);
        }

        [HttpPost]
        public ActionResult Create(MovimentoView movimentoView)
        {
            _logger.Info($"Create [INICIO]|movimentoView: {movimentoView}");

            AdicionarMovimentoRequest adicionarMovimentoRequest = 
                _mapper.Map<MovimentoView, AdicionarMovimentoRequest>(movimentoView);

            bool resultado = _movimentoServico.Adicionar(adicionarMovimentoRequest);

            if (resultado)
            {
                _logger.Info($"Create [FIM]|resultado: {resultado}");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Alerta = "Erro ao cadastrar movimento.";
                ListarProduto();
                _logger.Warn($"Create [FIM]|resultado: {resultado} Alerta: {ViewBag.Alerta}");
                return View(movimentoView);
            }
        }

        [HttpGet]
        public JsonResult GetCosifs(int codigoProduto)
        {
            _logger.Info($"GetCosifs [INICIO]|codigoProduto: {codigoProduto}");

            IEnumerable<CosifResponse> cosifs = _cosifServico.ListarAtivoPorProduto(codigoProduto);

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

        private void ListarProduto()
        {
            _logger.Info("ListarProduto [INICIO]");

            IEnumerable<ProdutoResponse> produtos = _produtoServico.ListarAtivo();

            ViewBag.Produtos = new SelectList(
                produtos.OrderBy(x => x.Descricao),
                "Codigo",
                "Descricao"
                );

            produtos = null;

            _logger.Info("ListarProduto [FIM]");
        }
    }
}