using Exame.DAO.Interface.Repositorio.Base;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.DAO.Interface.Repositorio
{
    public interface ICosifRepositorio : IListaRepositorio<Cosif>
    {
        ICollection<Cosif> ListarPorStatusPorProduto(string status, int codigoProduto);
    }
}
