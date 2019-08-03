using System.Collections.Generic;

namespace Exame.VO.Interface.Servico
{
    public interface IProdutoServico
    {
        IEnumerable<Produto> ListarAtivo();
    }
}
