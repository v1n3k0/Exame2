using Exame.VO;
using System.Collections.Generic;

namespace Exame.DAO.Interface.Repositorio
{
    public interface ICosifRepositorio
    {
        IEnumerable<Cosif> ListarPorStatusPorProduto(string status, int codigoProduto);
    }
}
