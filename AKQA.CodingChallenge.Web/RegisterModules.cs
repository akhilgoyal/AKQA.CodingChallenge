using System.Configuration;
using System.Web.Mvc;
using AKQA.CodingChallenge.Web.Controllers;
using Autofac;
using Autofac.Integration.Mvc;
using IContainer = Autofac.IContainer;

namespace AKQA.CodingChallenge.Web
{
    public static class RegisterModules
    {
        public static IContainer Register()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register<IResultClient>(c=> new ResultClient(ConfigurationManager.AppSettings["ApiLocation"])); ;

            containerBuilder.Register(c => new HomeController(c.Resolve<IResultClient>())); ;
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}