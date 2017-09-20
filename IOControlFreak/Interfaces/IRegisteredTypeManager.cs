using System;
using IOControlFreak.Models;

namespace IOControlFreak.Interfaces
{
    public interface IRegisteredTypeManager
    {
        RegisteredObjectInfo this[Type type] { get; }
        bool TryGetValue(Type type, out RegisteredObjectInfo objectInfo);
        void RegisterType(Type type, RegisteredObjectInfo objectInfo);
    }
}