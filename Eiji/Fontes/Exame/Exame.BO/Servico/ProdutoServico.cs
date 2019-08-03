using AutoMapper;
using Exame.DAO.Repositorio;
using Exame.VO;
using Exame.VO.Argumento.Produto;
using Exame.VO.Interface.Repositorio;
using Exame.VO.Interface.Servico;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _repoProduto = new ProdutoRepositorio();
        private readonly IMapper _mapper;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ProdutoServico()
        {
            MapperConfiguration ConfiguracaoMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoResponse>();
            });

            ConfiguracaoMapper.AssertConfigurationIsValid();
            _mapper = ConfiguracaoMapper.CreateMapper();
        }

        public IEnumerable<ProdutoResponse> ListarAtivo()
        {
            _logger.Info("ListarAtivo [INICIO]");

            IEnumerable<Produto> produtos = _repoProduto.ListarPorStatus("A");
            IEnumerable<ProdutoResponse> produtosResponse = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoResponse>>(produtos);

            _logger.Info("ListarAtivo [FIM]");
            return produtosResponse;
        }
    }
}
