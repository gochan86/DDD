
using Project.Crosscutting.Bootstrapper;
using Project.Tools;
using System.Web.Http;

namespace ProvidersService.App_Start
{
    public static class IocConfig
    {
        public static void Initialize()
        {
            //GlobalConfiguration.Configuration.DependencyResolver = ApplicationContext.Container.GetDependencyResolverWebApi();
            IocRegistration.Register(ApplicationContext.Container);
        }
    }
}