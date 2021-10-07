using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using AutoMapper;
using BookService.IoC;
using BookService.TypeConverters;
using Castle.Windsor;

namespace BookService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer _container;

        public WebApiApplication()
        {
            _container = new WindsorContainer();
            var controllersInstaller = new ConrollersInstaller();
            var servicesInstaller = new ServicesInstaller();
            var repositoriesInstaller = new RepositoriesInstaller();
            var automapperInstaller = new AutoMapperInstaller();
            _container.Install(servicesInstaller);
            _container.Install(controllersInstaller);
            _container.Install(repositoriesInstaller);
            _container.Install(automapperInstaller);
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));

            // Create and register a dependency resolver (this is required by the filters for dependency injection).
            // var dependencyResolver = new WindsorDependencyResolver(_container);
            // GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public override void Dispose()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}
