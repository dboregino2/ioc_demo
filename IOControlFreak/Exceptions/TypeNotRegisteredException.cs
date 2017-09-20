using System;
using System.Collections.Generic;
using System.Text;

namespace IOControlFreak.Exceptions
{
    public class TypeNotRegisteredException: Exception
    {

        public TypeNotRegisteredException(Type type):
        base($"Error resolving Type {type}.  No implementation has been registered")
        {
             
        }
    }
}
