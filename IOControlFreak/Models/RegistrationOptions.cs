using System;
using System.Collections.Generic;
using System.Text;
using static IOControlFreak.Enums;

namespace IOControlFreak.Models
{
    public class RegistrationOptions
    {
        public RegistrationOptions()
        {
            LifeCycle = LifeCycleType.Transient;
            AllowMultiple = false;
        }
        public LifeCycleType LifeCycle { get; set; }
        public bool AllowMultiple { get; set; }
    }
}
