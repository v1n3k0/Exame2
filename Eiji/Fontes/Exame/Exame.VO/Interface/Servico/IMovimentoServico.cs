using Exame.VO.Argumento.Movimento;
using System.Collections.Generic;

namespace Exame.VO.Interface.Servico
{
    public interface IMovimentoServico
    {
        IEnumerable<MovimentoProdutoResponse> ListarMovimentosProduto();

        bool Adicionar(AdicionarMovimentoRequest adicionarMovimentoRequest);
    }
}
