using Exame.BO.Servico;
using Exame.DAO;
using Exame.DAO.Repositorio;
using Exame.VO.Interface.Banco;
using Exame.VO.Interface.Repositorio;
using Exame.VO.Interface.Servico;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace Exame.Web.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();

            //DAO
            container.Register<IConexao, Conexao>();
            container.Register<ICosifRepositorio, CosifRepositorio>();
            container.Register<IMovimentoRepositorio, MovimentoRepositorio>();
            container.Register<IProdutoRepositorio, ProdutoRepositorio>();

            //BO
            container.Register<ICosifServico, CosifServico>();
            container.Register<IMovimentoServico, MovimentoServico>();
            container.Register<IProdutoServico, ProdutoServico>();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}