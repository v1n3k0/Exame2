using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.DAO.Interface.Repositorio
{
    public interface IMovimentoRepositorio
    {
        bool Adicionar(Movimento movimento);

        List<MovimentoProduto> ListarMovimentoProduto();

        int MaximoNumeroLancamento(int mes, int ano);
    }
}
