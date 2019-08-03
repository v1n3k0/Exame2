using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.VO.Interface.Servico
{
    public interface IMovimentoServico
    {
        IEnumerable<MovimentoProduto> ListarMovimentosProduto();

        bool Adicionar(int mes, int ano, int codigoProduto, int codigoCosif, int valor,
            string descricao);
    }
}
