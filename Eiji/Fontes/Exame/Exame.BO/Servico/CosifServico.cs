using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class CosifServico : ICosifServico
    {
        private readonly ICosifRepositorio _repoCosif = new CosifRepositorio();
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public IEnumerable<Cosif> ListarAtivoPorProduto(int codigoProduto)
        {
            _logger.Info($"ListarAtivoPorProduto [INICIO]|codigoProduto: {codigoProduto}");

            IEnumerable<Cosif> cosifs = _repoCosif.ListarPorStatusPorProduto("A", codigoProduto);

            _logger.Info("ListarAtivoPorProduto [FIM]");
            return cosifs;
        }
    }
}
