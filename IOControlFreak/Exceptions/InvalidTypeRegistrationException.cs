using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Exceptions
{
    public class InvalidTypeRegistrationException:Exception
    {
        public InvalidTypeRegistrationException(Type interfaceType, Type implementationType):
         base($"Invalid Container Registration {implementationType} does not implement Interface {interfaceType}")
        {
        }
    }
}
