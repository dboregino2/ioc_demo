using System;
using System.Collections.Generic;
using System.Text;

namespace IOControlFreak.Models
{
    public class RegisteredSingletonObject<T>
    where T: class
    {
        public T Implementation;
        //public Dictionary<string, T> NamedImplementations;
    }
}
