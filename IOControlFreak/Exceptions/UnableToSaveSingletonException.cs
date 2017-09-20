using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Exceptions
{
    public class UnableToSaveSingletonException:Exception
    {

        public UnableToSaveSingletonException(Type type):
         base($"Unable to store Singleton of type {type}" )       
        {

        }

    }
}
