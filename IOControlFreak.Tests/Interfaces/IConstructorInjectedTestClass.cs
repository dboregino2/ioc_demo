using IOControlFreak.Tests.Interfaces;

namespace IOControlFreak.Tests.Interfaces
{

    public interface IConstructorInjectedTestClass
    {
        ISingletonTestClass SingletonProperty { get; set; }
        ITransientTestClass TransientProperty { get; set; }
    }
}