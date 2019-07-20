using Exame.VO;
using System.Collections.Generic;

namespace Exame.DAO.Interface.Repositorio
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> ListarPorStatus(string status);
    }
}
