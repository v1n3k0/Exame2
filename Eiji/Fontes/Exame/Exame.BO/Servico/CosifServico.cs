using Exame.BO.Interface.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.Help.Extensao;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class CosifServico : ICosifServico
    {
        private readonly ICosifRepositorio _repoCosif;
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public CosifServico(ICosifRepositorio cosifRepositorio) => _repoCosif = cosifRepositorio;

        /// <summary>
        /// Listar Cosif pelo status ativo e codigo do produto
        /// </summary>
        /// <param name="codigoProduto">Codigo do Produto</param>
        /// <returns>Lista de Cosif</returns>
        public ICollection<Cosif> ListarAtivoPorProduto(int codigoProduto)
        {
            _logger.Info("ListarAtivoPorProduto [INICIO]|codigoProduto: {0}", codigoProduto);

            ICollection<Cosif> cosifs = _repoCosif.ListarPorStatusPorProduto("A", codigoProduto);

            _logger.Info("ListarAtivoPorProduto [FIM]| cosifsResponse: {0}", cosifs.SerializarXML());
            return cosifs;
        }
    }
}
