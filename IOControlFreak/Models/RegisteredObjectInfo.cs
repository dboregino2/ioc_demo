using System;
using System.Collections.Generic;
using System.Text;
using static IOControlFreak.Enums;

namespace IOControlFreak.Models
{
    public class RegisteredObjectInfo: RegistrationOptions
    {
        public RegisteredObjectInfo() { }
        public RegisteredObjectInfo(RegistrationOptions opts)
        {
            base.AllowMultiple = opts.AllowMultiple;
            base.LifeCycle = opts.LifeCycle;
        }
        public Type ImplementationType { get; set; }
        public Dictionary<string, Type> NamedImplementations { get; set; }
    }
}
