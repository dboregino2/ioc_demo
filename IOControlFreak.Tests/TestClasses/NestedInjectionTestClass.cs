using IOControlFreak.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Tests.TestClasses
{
    public class NestedInjectionTestClass : INestedInjectionTestClass
    {
        public NestedInjectionTestClass(IConstructorInjectedTestClass nestedInstance)
        {
            NestedInstance = nestedInstance;
        }
        public IConstructorInjectedTestClass NestedInstance { get; set; }
    }
}
