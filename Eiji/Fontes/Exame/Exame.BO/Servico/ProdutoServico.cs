using AutoMapper;
using Exame.BO.Mappers;
using Exame.VO;
using Exame.VO.Argumento.Produto;
using Exame.VO.Interface.Repositorio;
using Exame.VO.Interface.Servico;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _repoProduto;
        private readonly IMapper _mapper;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _repoProduto = produtoRepositorio;
            _mapper = AutoMapperServiceConfig.Mapper;
        }

        /// <summary>
        /// Listar Produto pelo status ativo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProdutoResponse> ListarAtivo()
        {
            _logger.Info("ListarAtivo [INICIO]");

            IEnumerable<Produto> produtos = _repoProduto.ListarPorStatus("A");
            IEnumerable<ProdutoResponse> produtosResponse = _mapper.Map<IEnumerable<ProdutoResponse>>(produtos);

            _logger.Info("ListarAtivo [FIM]");
            return produtosResponse;
        }
    }
}
