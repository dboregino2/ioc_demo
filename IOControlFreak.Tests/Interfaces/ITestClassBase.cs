namespace IOControlFreak.Tests.Interfaces
{
    public interface ITestClassBase
    {
        string InstanceName { get; set; }
        int TimesResolved { get; set; }
    }
}