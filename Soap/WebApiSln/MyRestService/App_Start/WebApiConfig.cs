using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MyRestService.Business;
using MyRestService.Business.Interfaces;
using MyRestService.Repository;
using MyRestService.Repository.Interfaces;
using Unity;
using Unity.Lifetime;

namespace MyRestService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserBusiness, UserBusiness>(new HierarchicalLifetimeManager());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
