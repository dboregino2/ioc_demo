using AcmeStorageUnitRental.DataLayer;
using IOControlFreak;
using IOControlFreak.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AcmeStorageUnitRental
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ICFContainer container = new CFContainer();
            RegisterCFInjectionTypes(container);
            DependencyResolver.SetResolver(new CFDependencyResolver(container,DependencyResolver.Current));

        }




        protected void RegisterCFInjectionTypes(ICFContainer container)
        {
            container.Register<IStorageUnitRepository, StorageUnitRepository>();
        }

    }
}
