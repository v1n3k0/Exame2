using Exame.DAO.Interface.Repositorio.Base;
using Exame.VO;

namespace Exame.DAO.Interface.Repositorio
{
    public interface IMovimentoRepositorio : IListaRepositorio<Movimento>
    {
        bool Adicionar(Movimento movimento);
        
        int MaximoNumeroLancamento(int mes, int ano);
    }
}
