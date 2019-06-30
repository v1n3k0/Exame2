using Exame.DAO.Repositorio;
using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System;
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

        public bool Adicionar(Movimento movimento)
        {
            movimento.DataMovimento = DateTime.Now;
            movimento.NumeroLancamento = _repoMovimento.GerarNumeroLancamento(movimento.Mes, movimento.Ano);
            movimento.CodigoUsuario = "TESTE";

            bool resultado = _repoMovimento.Adicionar(movimento);

            return resultado;
        }
    }
}
