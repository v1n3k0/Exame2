using Exame.BO.Interface.Servico;
using Exame.BO.Servico;
using Exame.VO;
using Exame.VO.Entidade.Procedure;
using Exame.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exame.Web.Controllers
{
    public class MovimentoController : Controller
    {
        private readonly IProdutoServico _produtoServico = new ProdutoServico();
        private readonly ICosifServico _cosifServico = new CosifServico();
        private readonly IMovimentoServico _movimentoServico = new MovimentoServico();
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: Movimento
        [HttpGet]
        public ActionResult Index()
        {
            _logger.Info("Index [INICIO]");

            IEnumerable<MovimentoProduto> movimentos = _movimentoServico.ListarMovimentosProduto();

            IEnumerable<MovimentoProdutoView> movimentosProduto = movimentos.Select(x => (MovimentoProdutoView)x);

            movimentos = null;

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

            bool resultado = _movimentoServico.Adicionar(
                movimentoView.Mes,
                movimentoView.Ano,
                movimentoView.CodigoProduto,
                movimentoView.CodigoCosif,
                movimentoView.Valor,
                movimentoView.Descricao);

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

            IEnumerable<Cosif> cosifs = _cosifServico.ListarAtivoPorProduto(codigoProduto);

            var cosifsList = new SelectList(
                cosifs.Select(x => new
                {
                    x.Codigo,
                    Descricao = $"{x.Codigo} - ({x.Status})"
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

            IEnumerable<Produto> produtos = _produtoServico.ListarAtivo();

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