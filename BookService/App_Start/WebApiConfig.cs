using BookService.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Castle.Core.Logging;

namespace BookService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var logger = (ILogger)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger));
            config.Filters.Add(new UnhandledExceptionFilter(logger));
        }
    }
}
