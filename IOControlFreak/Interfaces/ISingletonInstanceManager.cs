using System;

namespace IOControlFreak.Interfaces
{
    public interface ISingletonInstanceManager:IDisposable
    {
        object GetSingletonInstance(Type type);
        bool AddSingletonInstance(Type type, object singleton);
        void RemoveSingletonInstance(Type type);
    }
}