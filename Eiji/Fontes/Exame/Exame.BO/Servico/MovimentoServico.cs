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

        public List<MovimentoProduto> ListarMovimentosProduto()
        {
            List<MovimentoProduto> movimentosProduto = _repoMovimento.ListarMovimentoProduto();

            return movimentosProduto;
        }

        public bool Adicionar(Movimento movimento)
        {
            movimento.DataMovimento = DateTime.Now;
            movimento.NumeroLancamento = GerarNumeroLancamento(movimento.Mes, movimento.Ano);
            movimento.CodigoUsuario = "TESTE";

            bool resultado = _repoMovimento.Adicionar(movimento);

            return resultado;
        }

        private int GerarNumeroLancamento(int mes, int ano)
        {
            int numeroLancamento = _repoMovimento.MaximoNumeroLancamento(mes, ano) + 1;

            return numeroLancamento;
        }
    }
}
