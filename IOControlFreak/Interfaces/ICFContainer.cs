using IOControlFreak.Models;
using System;

namespace IOControlFreak.Interfaces
{
    public interface ICFContainer:IDisposable
    {
        void Register<I, T>(Enums.LifeCycleType lifeCycleType = Enums.LifeCycleType.Transient)
            where I : class
            where T : class;
        void Register<I, T>(RegistrationOptions opts)
            where I : class
            where T : class;
        T Resolve<T>();
        object Resolve(Type interfaceType);
    }
}