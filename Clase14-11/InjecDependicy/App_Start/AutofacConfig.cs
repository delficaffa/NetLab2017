using Autofac;
using Autofac.Integration.Mvc;

using System.Web.Mvc;

namespace InjecDependicy.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ClientLogic>().As<IClientLogic>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
    
}