using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _repoProduto = new ProdutoRepositorio();
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public IEnumerable<Produto> ListarAtivo()
        {
            _logger.Info("ListarAtivo [INICIO]");

            IEnumerable<Produto> produtos = _repoProduto.ListarPorStatus("A");

            _logger.Info("ListarAtivo [FIM]");
            return produtos;
        }
    }
}
