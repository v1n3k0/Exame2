using AutoMapper;
using Exame.DAO.Repositorio;
using Exame.VO;
using Exame.VO.Argumento.Cosif;
using Exame.VO.Interface.Repositorio;
using Exame.VO.Interface.Servico;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class CosifServico : ICosifServico
    {
        private readonly ICosifRepositorio _repoCosif = new CosifRepositorio();
        private readonly IMapper _mapper;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public CosifServico()
        {
            MapperConfiguration ConfiguracaoMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cosif, CosifResponse>();
            });

            ConfiguracaoMapper.AssertConfigurationIsValid();
            _mapper = ConfiguracaoMapper.CreateMapper();
        }

        public IEnumerable<CosifResponse> ListarAtivoPorProduto(int codigoProduto)
        {
            _logger.Info($"ListarAtivoPorProduto [INICIO]|codigoProduto: {codigoProduto}");

            IEnumerable<Cosif> cosifs = _repoCosif.ListarPorStatusPorProduto("A", codigoProduto);
            IEnumerable<CosifResponse> cosifsResponse = _mapper.Map<IEnumerable<Cosif>, IEnumerable<CosifResponse>>(cosifs);

            _logger.Info("ListarAtivoPorProduto [FIM]");
            return cosifsResponse;
        }
    }
}
