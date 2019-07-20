using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Interface.Servico
{
    public interface ICosifServico
    {
        IEnumerable<Cosif> ListarAtivoPorProduto(int codigoProduto);
    }
}
