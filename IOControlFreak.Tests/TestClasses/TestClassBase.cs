using IOControlFreak.Tests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Tests.TestClasses
{
    public abstract class TestClassBase : ITestClassBase
    {
        public string InstanceName { get; set; }
        public int TimesResolved { get; set; }
    }
}
