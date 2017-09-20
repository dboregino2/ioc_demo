using IOControlFreak.Exceptions;
using IOControlFreak.Interfaces;
using IOControlFreak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static IOControlFreak.Enums;

namespace IOControlFreak
{
    public class CFContainer : ICFContainer
    {
        #region Private variables
        private IRegisteredTypeManager _typeManager;
        private ISingletonInstanceManager _singletonManager;
        private IRegistrationValidator _registrationValidator;
        #endregion

        public CFContainer(IRegisteredTypeManager typeManager, ISingletonInstanceManager singletonManager, IRegistrationValidator registrationValidator)
        {
            _singletonManager = singletonManager;
            _typeManager = typeManager;
            _registrationValidator = registrationValidator;
            init();
        }
        public CFContainer()
        {
            init();
            
        }                
        public void Register<I, T>(LifeCycleType lifeCycleType = LifeCycleType.Transient)
             where I : class
             where T : class
        {
            if(_registrationValidator.ValidateRegistrationTypes(typeof(I), typeof(T)))
            {
                _typeManager.RegisterType(typeof(I), new RegisteredObjectInfo() { LifeCycle = lifeCycleType, ImplementationType = typeof(T) });
            }
            else
            {
                throw _registrationValidator.ValidationException;
            }

            
        }
        public void Register<I, T>(RegistrationOptions opts)
        where I : class
        where T : class
        {

            if (_registrationValidator.ValidateRegistrationTypes(typeof(I), typeof(T)))
            {
                _typeManager.RegisterType(typeof(I), new RegisteredObjectInfo(opts) {ImplementationType = typeof(T) });
            }
            else
            {
                throw _registrationValidator.ValidationException;
            }
            
        }
        public T Resolve<T>()
        {
           return (T)Resolve(typeof(T));
        }        
        public object Resolve(Type interfaceType)
        {
            if (interfaceType == typeof(ICFContainer))
                return this;


            object resolvedObject = null;
            RegisteredObjectInfo typeInfo;    
            if (_typeManager.TryGetValue(interfaceType, out typeInfo))
            {

                switch (typeInfo.LifeCycle)
                {
                    case Enums.LifeCycleType.Singleton:
                        resolvedObject = _singletonManager.GetSingletonInstance(interfaceType);
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

                    if (typeInfo.LifeCycle == Enums.LifeCycleType.Singleton)
                    {
                      bool singletonInitiated =  _singletonManager.AddSingletonInstance(interfaceType, resolvedObject);

                        //this means another process created the singleton after the check above
                        if(singletonInitiated == false)
                        {
                            throw new InvalidOperationException($"Failed to store Singleton of type {interfaceType}");
                        }

                    }

                }

            }
            else
            {
                throw new TypeNotRegisteredException(interfaceType);
            }
            return resolvedObject;
        }
        private void init()
        {
            if(_typeManager == null)
            _typeManager = new RegisteredTypeManager();

            if(_registrationValidator == null)
            _registrationValidator = new RegistrationValidator();

            if(_singletonManager == null)
            _singletonManager = new SingletonInstanceManager(_registrationValidator);
        }
        public void Dispose()
        {
            _singletonManager.Dispose();
        }
    }
}
