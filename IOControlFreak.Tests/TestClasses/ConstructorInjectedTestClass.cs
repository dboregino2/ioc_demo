using IOControlFreak.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Tests.TestClasses
{
    public class ConstructorInjectedTestClass : IConstructorInjectedTestClass
    {
        public ConstructorInjectedTestClass(ITransientTestClass _transientProperty, ISingletonTestClass _singletonProperty)
        {
            TransientProperty = _transientProperty;
            SingletonProperty = _singletonProperty;
        }
        public ITransientTestClass TransientProperty { get; set; }
        public ISingletonTestClass SingletonProperty { get; set; }
    }
}

