using Exame.VO.Argumento.Produto;
using System.Collections.Generic;

namespace Exame.VO.Interface.Servico
{
    public interface IProdutoServico
    {
        IEnumerable<ProdutoResponse> ListarAtivo();
    }
}
