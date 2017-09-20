using IOControlFreak.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOControlFreak
{
    public class SingletonInstanceManager : ISingletonInstanceManager
    {
        #region Private Variables       
        private ConcurrentDictionary<Type, Object> _singletonDictionary;
        private IRegistrationValidator _registrationValidator;
        #endregion

        #region Constructors
        public SingletonInstanceManager(IRegistrationValidator registrationValidator)
        {
            _singletonDictionary = new ConcurrentDictionary<Type, object>();
            _registrationValidator = registrationValidator;
        } 
        #endregion
        public object GetSingletonInstance(Type type)
        {
            object returnObj = null;
            _singletonDictionary.TryGetValue(type, out returnObj);
           
             return returnObj;           
        }
        public bool AddSingletonInstance(Type type, object instance)
        {
            if(instance == null)
            {
                throw new InvalidOperationException($"Error storing singleton of type {type}. Null objects cannot be stored as singletons.");
            }
            else if(_registrationValidator.ValidateRegistrationTypes(type, instance.GetType()) == false)
            {
                throw _registrationValidator.ValidationException;
            }
             return _singletonDictionary.TryAdd(type, instance);
            
        }
        public void RemoveSingletonInstance(Type type)
        {
            object resolvedObj = null;
            if (_singletonDictionary.TryRemove(type, out resolvedObj))          
                TryDisposeObject(resolvedObj);
          
        }
        public void Dispose()
        {
            
            _singletonDictionary.Values.ToList().ForEach(o =>
            {
                TryDisposeObject(o);
               
            });
        }
        // for cleaning up individual objects
        private void TryDisposeObject(object o)
        {
            if (o == null)
                return;

            var disp = o as IDisposable;
            if (disp != null)
                disp.Dispose();
        }
        
    }
}
