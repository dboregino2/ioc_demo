using System;
using System.Collections.Generic;
using System.Text;

namespace IOControlFreak.Exceptions
{
    public class TypeAlreadyRegisteredException : Exception
    {

        public TypeAlreadyRegisteredException(Type abstraction, Type implementation):
            base($"Unable to register type {abstraction} and implementation {implementation}. {abstraction} is already registered.")
        {

        }
    }
}
