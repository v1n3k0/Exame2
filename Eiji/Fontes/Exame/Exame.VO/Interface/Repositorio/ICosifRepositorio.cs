using System.Collections.Generic;

namespace Exame.VO.Interface.Repositorio
{
    public interface ICosifRepositorio
    {
        IEnumerable<Cosif> ListarPorStatusPorProduto(string status, int codigoProduto);
    }
}
