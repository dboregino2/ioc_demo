using IOControlFreak.Exceptions;
using IOControlFreak.Interfaces;
using System;

namespace IOControlFreak
{
    public class RegistrationValidator : IRegistrationValidator
    {

        public Exception ValidationException { get; private set; }
        public bool ValidateRegistrationTypes(Type interfaceType, Type implementationType)
        {
            bool valid = true;
            ValidationException = null;

            if (!interfaceType.IsInterface)
            {
                ValidationException = new InvalidOperationException($"{interfaceType} is not a valid registration type. Registered keys must be interface types");
                valid = false;
            }
            else if (!interfaceType.IsAssignableFrom(implementationType))
            {
                ValidationException = new InvalidTypeRegistrationException(interfaceType, implementationType);
                valid = false;
            }
            return valid;
        }
    }
}
