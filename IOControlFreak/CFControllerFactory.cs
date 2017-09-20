using IOControlFreak.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace IOControlFreak
{
    public class CFControllerFactory:DefaultControllerFactory
    {
        private ICFContainer _container;

        public CFControllerFactory(ICFContainer container)
        {
            _container = container;
        }     


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;


            var constructor = controllerType.GetConstructors().First();

            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return  (IController)Activator.CreateInstance(controllerType);
            }
            else
            {
                List<object> parameters = new List<object>(constructorParameters.Length);
                foreach (ParameterInfo parameterInfo in constructorParameters)
                {
                    parameters.Add(_container.Resolve(parameterInfo.ParameterType));
                }
                return (IController) constructor.Invoke(parameters.ToArray());
            }
            
        }
    }
}
