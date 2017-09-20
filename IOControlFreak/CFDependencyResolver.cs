using IOControlFreak.Exceptions;
using IOControlFreak.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace IOControlFreak
{
    public class CFDependencyResolver : IDependencyResolver
    {

        private ICFContainer _container;
        private IDependencyResolver _defaultResolver;
        public CFDependencyResolver(ICFContainer container, IDependencyResolver defaultResolver)
        {           
            container.Register<IControllerFactory, CFControllerFactory>();
            _defaultResolver = defaultResolver;
             _container = container;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            object returnObj = null;
            try
            {
                returnObj = _container.Resolve(serviceType);
            }
            catch(TypeNotRegisteredException er)
            {
                Console.Write(er.Message);
                returnObj = _defaultResolver.GetService(serviceType);
            }          

            return returnObj;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _defaultResolver.GetServices(serviceType);
        }
    }
}
