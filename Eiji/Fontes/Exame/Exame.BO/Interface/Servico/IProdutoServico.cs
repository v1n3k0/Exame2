using Exame.VO;
using System.Collections.Generic;

namespace Exame.BO.Interface.Servico
{
    public interface IProdutoServico
    {
        IEnumerable<Produto> ListarAtivo();
    }
}
