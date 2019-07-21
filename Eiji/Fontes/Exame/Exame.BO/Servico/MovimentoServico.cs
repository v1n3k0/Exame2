using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio;
using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class MovimentoServico : IMovimentoServico
    {
        private readonly IMovimentoRepositorio _repoMovimento = new MovimentoRepositorio();

        public List<MovimentoProduto> ListarMovimentosProduto()
        {
            List<MovimentoProduto> movimentosProduto = _repoMovimento.ListarMovimentoProduto();

            return movimentosProduto;
        }

        public bool Adicionar(int mes, int ano, int codigoProduto, int codigoCosif, int valor,
            string descricao)
        {
            int numeroLancamento = GerarNumeroLancamento(mes, ano);

            Movimento movimento = new Movimento(
                mes,
                ano,
                numeroLancamento,
                codigoProduto,
                codigoCosif,
                valor,
                descricao
                );

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
