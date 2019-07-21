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

        // GET: Movimento
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<MovimentoProduto> movimentos = _movimentoServico.ListarMovimentosProduto();

            IEnumerable<MovimentoProdutoView> movimentosProduto = movimentos.Select(x => (MovimentoProdutoView)x);

            movimentos = null;

            return View(movimentosProduto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var movimento = new MovimentoView();
            
            ListarProduto();

            return View(movimento);
        }

        [HttpPost]
        public ActionResult Create(MovimentoView movimentoView)
        {

            bool resultado = _movimentoServico.Adicionar(
                movimentoView.Mes,
                movimentoView.Ano,
                movimentoView.CodigoProduto,
                movimentoView.CodigoCosif,
                movimentoView.Valor,
                movimentoView.Descricao);

            if(resultado)
                return RedirectToAction("Index");
            else
            {
                ViewBag.Alerta = "Erro ao cadastrar movimento.";
                ListarProduto();
                return View(movimentoView);
            }
        }

        [HttpGet]
        public JsonResult getCosifs(int codigoProduto)
        {
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

            return Json(cosifsList, JsonRequestBehavior.AllowGet);
        }

        private void ListarProduto()
        {
            IEnumerable<Produto> produtos = _produtoServico.ListarAtivo();

            ViewBag.Produtos = new SelectList(
                produtos.OrderBy(x => x.Descricao),
                "Codigo",
                "Descricao"
                );

            produtos = null;
        }
    }
}