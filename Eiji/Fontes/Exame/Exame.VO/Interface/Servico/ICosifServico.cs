using Exame.VO.Argumento.Cosif;
using System.Collections.Generic;

namespace Exame.VO.Interface.Servico
{
    public interface ICosifServico
    {
        IEnumerable<CosifResponse> ListarAtivoPorProduto(int codigoProduto);
    }
}
