using Exame.DAO.Interface.Repositorio.Base;
using Exame.VO;
using System.Collections.Generic;

namespace Exame.DAO.Interface.Repositorio
{
    public interface IProdutoRepositorio : IListaRepositorio<Produto>
    {
        ICollection<Produto> ListarPorStatus(string status);
    }
}
