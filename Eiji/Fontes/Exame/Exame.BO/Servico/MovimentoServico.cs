using Exame.DAO.Repositorio;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class MovimentoServico
    {
        private readonly MovimentoRepositorio _repoMovimento = new MovimentoRepositorio();

        public IEnumerable<MovimentoProduto> ListarMovimentosProduto()
        {
            IEnumerable<MovimentoProduto> movimentosProduto = _repoMovimento.ListarMovimentoProduto();

            return movimentosProduto;
        }
    }
}
