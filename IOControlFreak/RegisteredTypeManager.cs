using IOControlFreak.Exceptions;
using IOControlFreak.Interfaces;
using IOControlFreak.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace IOControlFreak
{
    public class RegisteredTypeManager : IRegisteredTypeManager
    {
        #region Private Variables
        private ConcurrentDictionary<Type, RegisteredObjectInfo> _registeredTypes; 
        #endregion

        public RegisteredObjectInfo this[Type type]
        {
            get
            {
                RegisteredObjectInfo returnObj = null;
                _registeredTypes.TryGetValue(type, out returnObj);
                return returnObj;
            }

        }

        #region Constructors
        public RegisteredTypeManager()
        {
            _registeredTypes = new ConcurrentDictionary<Type, RegisteredObjectInfo>();
        }       
        #endregion


        public void RegisterType(Type type, RegisteredObjectInfo objectInfo)
        {
            bool objectAdded = _registeredTypes.TryAdd(type, objectInfo);
            if (objectAdded == false)
            {
                throw new TypeAlreadyRegisteredException(type, objectInfo.ImplementationType);
            }
                     
        }
        public bool TryGetValue(Type type, out RegisteredObjectInfo objectInfo)
        {
            return _registeredTypes.TryGetValue(type, out objectInfo);
        }
    }
}
