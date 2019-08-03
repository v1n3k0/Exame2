using AutoMapper;
using Exame.DAO.Repositorio;
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
        private readonly IMovimentoRepositorio _repoMovimento = new MovimentoRepositorio();
        private readonly IMapper _mapper;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public MovimentoServico()
        {
            MapperConfiguration ConfiguracaoMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MovimentoProduto, MovimentoProdutoResponse>();
            });

            ConfiguracaoMapper.AssertConfigurationIsValid();
            _mapper = ConfiguracaoMapper.CreateMapper();
        }

        public IEnumerable<MovimentoProdutoResponse> ListarMovimentosProduto()
        {
            _logger.Info("ListarMovimentosProduto [INICIO]");

            IEnumerable<MovimentoProduto> movimentosProduto = _repoMovimento.ListarMovimentoProduto();
            IEnumerable<MovimentoProdutoResponse> movimentosProdutoResponse = 
                _mapper.Map<IEnumerable<MovimentoProduto>, IEnumerable<MovimentoProdutoResponse>>(movimentosProduto);

            _logger.Info("ListarMovimentosProduto [FIM]");
            return movimentosProdutoResponse;
        }

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

        private int GerarNumeroLancamento(int mes, int ano)
        {
            _logger.Info($"GerarNumeroLancamento [INICIO]|mes: {mes}, ano: {ano}");

            int numeroLancamento = _repoMovimento.MaximoNumeroLancamento(mes, ano) + 1;

            _logger.Info($"GerarNumeroLancamento [FIM]|numeroLancamento: {numeroLancamento}");
            return numeroLancamento;
        }
    }
}
