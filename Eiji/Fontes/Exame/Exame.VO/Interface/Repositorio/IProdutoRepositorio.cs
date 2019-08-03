using System.Collections.Generic;

namespace Exame.VO.Interface.Repositorio
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> ListarPorStatus(string status);
    }
}
