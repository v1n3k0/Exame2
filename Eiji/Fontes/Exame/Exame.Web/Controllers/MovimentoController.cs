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
        private readonly ProdutoServico _produtoServico = new ProdutoServico();
        private readonly CosifServico _cosifServico = new CosifServico();
        private readonly MovimentoServico _movimentoServico = new MovimentoServico();

        // GET: Movimento
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<MovimentoProduto> movimentos = _movimentoServico.ListarMovimentosProduto();

            IEnumerable<MovimentoProdutoView> movimentosProduto = movimentos.ToList().Select(x => (MovimentoProdutoView)x);

            return View(movimentosProduto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var movimento = new MovimentoView();
            IEnumerable<Produto> produtos = _produtoServico.ListarAtivo();

            ViewBag.Produtos = new SelectList(
                produtos.OrderBy(x => x.Descricao),
                "Codigo",
                "Descricao"
                );

            return View(movimento);
        }

        [HttpPost]
        public ActionResult Create(MovimentoView movimento)
        {

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult getCosifs(int codigoProduto)
        {
            IEnumerable<Cosif> cosifs = _cosifServico.ListarAtivoPorProduto(codigoProduto);

            var cosifsList = new SelectList(
                cosifs.Select(x => new {
                    Codigo = x.Codigo,
                    Descricao = $"{x.Codigo} - ({x.Status})"
                }),
                "Codigo",
                "Descricao"
                );

            return Json(cosifsList, JsonRequestBehavior.AllowGet);
        }
    }
}