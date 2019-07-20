using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class ProdutoServico: IProdutoServico
    {
       private readonly IProdutoRepositorio _repoProduto = new ProdutoRepositorio();

        public IEnumerable<Produto> ListarAtivo()
        {
            IEnumerable<Produto> produtos = _repoProduto.ListarPorStatus("A");

            return produtos;
        }
    }
}
