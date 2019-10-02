using Exame.BO.Interface.Servico;
using Exame.BO.Servico;
using Exame.DAO.Interface.Repositorio;
using Exame.DAO.Repositorio;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace Exame.IoC
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();

            //DAO
            container.Register<ICosifRepositorio, CosifRepositorio>();
            container.Register<IMovimentoProdutoRepositorio, MovimentoProdutoRepositorio>();
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