using System;

namespace IOControlFreak.Interfaces
{
    public interface IRegistrationValidator
    {
        Exception ValidationException { get; }
        bool ValidateRegistrationTypes(Type interfaceType, Type implementationType);
    }
}