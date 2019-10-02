using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.Help.Extensao;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _repoProduto;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ProdutoServico(IProdutoRepositorio produtoRepositorio) => _repoProduto = produtoRepositorio;

        /// <summary>
        /// Listar Produto pelo status ativo
        /// </summary>
        /// <returns>Lista de Produto</returns>
        public ICollection<Produto> ListarAtivo()
        {
            _logger.Info("ListarAtivo [INICIO]");

            ICollection<Produto> produtos = _repoProduto.ListarPorStatus("A");

            _logger.Info("ListarAtivo [FIM]| produtosResponse: {0}", produtos.SerializarXML());
            return produtos;
        }
    }
}
