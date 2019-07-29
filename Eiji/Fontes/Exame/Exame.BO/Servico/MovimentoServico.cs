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
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public List<MovimentoProduto> ListarMovimentosProduto()
        {
            _logger.Info("ListarMovimentosProduto [INICIO]");

            List<MovimentoProduto> movimentosProduto = _repoMovimento.ListarMovimentoProduto();

            _logger.Info("ListarMovimentosProduto [FIM]");
            return movimentosProduto;
        }

        public bool Adicionar(int mes, int ano, int codigoProduto, int codigoCosif, int valor,
            string descricao)
        {
            _logger.Info($"Adicionar [INICIO]|mes: {mes}, ano: {ano}, codigoProduto: {codigoProduto}, codigoCosif: {codigoCosif}, valor: {valor}, descricao: {descricao}");

            int numeroLancamento = GerarNumeroLancamento(mes, ano);

            Movimento movimento = new Movimento(
                mes,
                ano,
                numeroLancamento,
                codigoProduto,
                codigoCosif,
                valor,
                descricao,
                "TESTE"
                );

            bool resultado = _repoMovimento.Adicionar(movimento);

            _logger.Info($"Adicionar [FIM]| resultado: {resultado}");
            return resultado;
        }

        private int GerarNumeroLancamento(int mes, int ano)
        {
            _logger.Info($"GerarNumeroLancamento [INICIO]|mes: {mes}, ano: {ano}");

            int numeroLancamento = _repoMovimento.MaximoNumeroLancamento(mes, ano) + 1;

            _logger.Info($"GerarNumeroLancamento [FIM]|numeroLancamento: {numeroLancamento}");
            return numeroLancamento;
        }
    }
}
