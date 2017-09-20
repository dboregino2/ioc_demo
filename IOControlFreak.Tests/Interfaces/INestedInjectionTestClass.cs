
namespace IOControlFreak.Tests.Interfaces
{
    public interface INestedInjectionTestClass
    {
        IConstructorInjectedTestClass NestedInstance { get; set; }
    }
}