using AutoMapper;
using Exame.BO.Mappers;
using Exame.VO;
using Exame.VO.Argumento.Cosif;
using Exame.VO.Interface.Repositorio;
using Exame.VO.Interface.Servico;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class CosifServico : ICosifServico
    {
        private readonly ICosifRepositorio _repoCosif;
        private readonly IMapper _mapper;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public CosifServico(ICosifRepositorio cosifRepositorio)
        {
            _repoCosif = cosifRepositorio;
            _mapper = AutoMapperServiceConfig.Mapper;
        }

        /// <summary>
        /// Listar Cosif pelo status ativo e codigo do produto
        /// </summary>
        /// <param name="codigoProduto">Codigo do Produto</param>
        /// <returns></returns>
        public IEnumerable<CosifResponse> ListarAtivoPorProduto(int codigoProduto)
        {
            _logger.Info($"ListarAtivoPorProduto [INICIO]|codigoProduto: {codigoProduto}");

            IEnumerable<Cosif> cosifs = _repoCosif.ListarPorStatusPorProduto("A", codigoProduto);
            IEnumerable<CosifResponse> cosifsResponse = _mapper.Map<IEnumerable<CosifResponse>>(cosifs);

            _logger.Info("ListarAtivoPorProduto [FIM]");
            return cosifsResponse;
        }
    }
}
