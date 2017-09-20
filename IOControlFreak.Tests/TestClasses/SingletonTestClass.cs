using IOControlFreak.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Tests.TestClasses
{
    public class SingletonTestClass:TestClassBase,ISingletonTestClass
    {
        public SingletonTestClass()
        {
            TimesResolved = 1;
            InstanceName = "SingletonInstance";
        }
        

    }
}
