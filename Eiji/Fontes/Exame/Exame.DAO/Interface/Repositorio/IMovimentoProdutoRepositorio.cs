using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.DAO.Interface.Repositorio
{
    public interface IMovimentoProdutoRepositorio
    {
        ICollection<MovimentoProduto> ListarTodos();
    }
}
