using Exame.DAO.Repositorio;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class ProdutoServico
    {
       private readonly ProdutoRepositorio  _repoProduto = new ProdutoRepositorio();

        public IEnumerable<Produto> ListarAtivo()
        {
            IEnumerable<Produto> produtos = _repoProduto.ListarPorStatus("A");

            return produtos;
        }
    }
}
