using IOControlFreak.Exceptions;
using IOControlFreak.Interfaces;
using IOControlFreak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IOControlFreak
{
    public class TypeResolver : ITypeResolver
    {
        public TypeResolver(IRegisteredTypeManager registeredTypes,ISingletonInstanceManager singletonManager)
        {
            RegisteredTypes = registeredTypes;
            SingletonManager = singletonManager;
        }
        protected IRegisteredTypeManager RegisteredTypes {get;set;}
        protected ISingletonInstanceManager SingletonManager { get; set; }
        public object Resolve(Type type)
        {
            object resolvedObject = null;
            RegisteredObjectInfo typeInfo;

            if (RegisteredTypes.TryGetValue(type, out typeInfo))
            {

                switch(typeInfo.LifeCycle)
                {
                    case Enums.LifeCycleType.Singleton:
                        resolvedObject = SingletonManager.GetSingletonInstance(typeInfo.ImplementationType);
                    break;                    
                }

                if (resolvedObject == null)
                {
                    ConstructorInfo constructor = typeInfo.ImplementationType.GetConstructors().ToList().FirstOrDefault();
                    ParameterInfo[] constructorParameters = constructor.GetParameters();
                    if (constructorParameters.Length == 0)
                    {
                        resolvedObject = Activator.CreateInstance(typeInfo.ImplementationType);
                    }
                    else
                    {
                        List<object> parameters = new List<object>(constructorParameters.Length);
                        foreach (ParameterInfo parameterInfo in constructorParameters)
                        {
                            parameters.Add(Resolve(parameterInfo.ParameterType));
                        }
                        resolvedObject = constructor.Invoke(parameters.ToArray());
                    }  
                    
                    if(typeInfo.LifeCycle == Enums.LifeCycleType.Singleton)
                    {
                        SingletonManager.AddSingletonInstance(typeInfo.ImplementationType, resolvedObject);
                    }

                }
                
            }
            else
            {
                throw new TypeNotRegisteredException(type);
            }
            return resolvedObject;
        }

    }
}
