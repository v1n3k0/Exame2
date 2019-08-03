using AutoMapper;
using Exame.VO;
using Exame.VO.Argumento.Movimento;
using Exame.VO.Entidade.Procedure;
using Exame.VO.Interface.Repositorio;
using Exame.VO.Interface.Servico;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class MovimentoServico : IMovimentoServico
    {
        private readonly IMovimentoRepositorio _repoMovimento;
        private readonly IMapper _mapper;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public MovimentoServico(IMovimentoRepositorio movimentoRepositorio)
        {
            _repoMovimento = movimentoRepositorio;

            MapperConfiguration ConfiguracaoMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovimentoProduto, MovimentoProdutoResponse>();
            });

            ConfiguracaoMapper.AssertConfigurationIsValid();
            _mapper = ConfiguracaoMapper.CreateMapper();
        }

        /// <summary>
        /// Listar MovimentoProduto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MovimentoProdutoResponse> ListarMovimentosProduto()
        {
            _logger.Info("ListarMovimentosProduto [INICIO]");

            IEnumerable<MovimentoProduto> movimentosProduto = _repoMovimento.ListarMovimentoProduto();
            IEnumerable<MovimentoProdutoResponse> movimentosProdutoResponse = 
                _mapper.Map<IEnumerable<MovimentoProduto>, IEnumerable<MovimentoProdutoResponse>>(movimentosProduto);

            _logger.Info("ListarMovimentosProduto [FIM]");
            return movimentosProdutoResponse;
        }

        /// <summary>
        /// Salvar Movimento
        /// </summary>
        /// <param name="adicionarMovimentoRequest">Dados do Movimento a ser salvo</param>
        /// <returns></returns>
        public bool Adicionar(AdicionarMovimentoRequest adicionarMovimentoRequest)
        {
            _logger.Info("Adicionar [INICIO]");

            int numeroLancamento = GerarNumeroLancamento(adicionarMovimentoRequest.Mes, adicionarMovimentoRequest.Ano);

            Movimento movimento = new Movimento(
                adicionarMovimentoRequest.Mes,
                adicionarMovimentoRequest.Ano,
                numeroLancamento,
                adicionarMovimentoRequest.CodigoProduto,
                adicionarMovimentoRequest.CodigoCosif,
                adicionarMovimentoRequest.Valor,
                adicionarMovimentoRequest.Descricao,
                "TESTE"
                );

            bool resultado = _repoMovimento.Adicionar(movimento);

            _logger.Info($"Adicionar [FIM]| resultado: {resultado}");
            return resultado;
        }

        /// <summary>
        /// Gerar novo Numero de lançamento
        /// </summary>
        /// <param name="mes">Mes do Movimento</param>
        /// <param name="ano">Ano do Movimento</param>
        /// <returns></returns>
        private int GerarNumeroLancamento(int mes, int ano)
        {
            _logger.Info($"GerarNumeroLancamento [INICIO]|mes: {mes}, ano: {ano}");

            int numeroLancamento = _repoMovimento.MaximoNumeroLancamento(mes, ano) + 1;

            _logger.Info($"GerarNumeroLancamento [FIM]|numeroLancamento: {numeroLancamento}");
            return numeroLancamento;
        }
    }
}
