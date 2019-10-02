using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.Help.Extensao;
using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class MovimentoServico : IMovimentoServico
    {
        private readonly IMovimentoRepositorio _repoMovimento;
        private readonly IMovimentoProdutoRepositorio _repoMovimentoProduto;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public MovimentoServico(IMovimentoRepositorio movimentoRepositorio, IMovimentoProdutoRepositorio movimentoProdutoRepositorio)
        {
            _repoMovimento = movimentoRepositorio;
            _repoMovimentoProduto = movimentoProdutoRepositorio;
        }

        /// <summary>
        /// Listar MovimentoProduto
        /// </summary>
        /// <returns>Lista de MovimentoProduto</returns>
        public ICollection<MovimentoProduto> ListarMovimentosProduto()
        {
            _logger.Info("ListarMovimentosProduto [INICIO]");

            ICollection<MovimentoProduto> movimentosProduto = _repoMovimentoProduto.ListarTodos();

            _logger.Info("ListarMovimentosProduto [FIM]| movimentosProdutoResponse: {0}", movimentosProduto.SerializarJson());
            return movimentosProduto;
        }

        /// <summary>
        /// Salvar Movimento
        /// </summary>
        /// <param name="adicionarMovimentoRequest">Dados do Movimento a ser salvo</param>
        /// <returns>Resultado da ação</returns>
        public bool Adicionar(Movimento movimento)
        {
            _logger.Info("Adicionar [INICIO]| adicionarMovimentoRequest: {0}", movimento.SerializarXML());

            movimento.NumeroLancamento = GerarNumeroLancamento(movimento.Mes, movimento.Ano);
            movimento.DataMovimento = DateTime.Now;
            movimento.CodigoUsuario = "TESTE";

            bool resultado = _repoMovimento.Adicionar(movimento);

            _logger.Info("Adicionar [FIM]| resultado: {0}", resultado);
            return resultado;
        }

        /// <summary>
        /// Gerar novo Numero de lançamento
        /// </summary>
        /// <param name="mes">Mes do Movimento</param>
        /// <param name="ano">Ano do Movimento</param>
        /// <returns>Novo numero de lançamento</returns>
        private int GerarNumeroLancamento(int mes, int ano)
        {
            _logger.Info("GerarNumeroLancamento [INICIO]|mes: {0}, ano: {1}", mes, ano);

            int numeroLancamento = _repoMovimento.MaximoNumeroLancamento(mes, ano) + 1;

            _logger.Info("GerarNumeroLancamento [FIM]|numeroLancamento: {0}", numeroLancamento);
            return numeroLancamento;
        }
    }
}
