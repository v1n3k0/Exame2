using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Interface.Servico
{
    public interface ICosifServico
    {
        ICollection<Cosif> ListarAtivoPorProduto(int codigoProduto);
    }
}
