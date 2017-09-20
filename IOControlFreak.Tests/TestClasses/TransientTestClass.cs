using IOControlFreak.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Tests.TestClasses
{
    public class TransientTestClass:TestClassBase,ITransientTestClass
    {
        public TransientTestClass()
        {
            TimesResolved = 1;
            InstanceName = "TransientInstance";
        }

    }
}
