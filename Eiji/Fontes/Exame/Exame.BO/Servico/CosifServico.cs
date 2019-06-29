using Exame.DAO.Repositorio;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Servico
{
    public class CosifServico
    {
        private readonly CosifRepositorio _repoCosif = new CosifRepositorio();

        public IEnumerable<Cosif> ListarAtivoPorProduto(int codigoProduto)
        {
            IEnumerable<Cosif> cosifs = _repoCosif.ListarPorStatusPorProduto("A", codigoProduto);

            return cosifs;
        }
    }
}
