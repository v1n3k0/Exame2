using System.Collections.Generic;

namespace Exame.VO.Interface.Servico
{
    public interface ICosifServico
    {
        IEnumerable<Cosif> ListarAtivoPorProduto(int codigoProduto);
    }
}
