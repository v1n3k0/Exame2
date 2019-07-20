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

        public IEnumerable<Cosif> ListarAtivoPorProduto(int codigoProduto)
        {
            IEnumerable<Cosif> cosifs = _repoCosif.ListarPorStatusPorProduto("A", codigoProduto);

            return cosifs;
        }
    }
}
