using IOControlFreak.Tests.Interfaces;

namespace IOControlFreak.Tests.TestClasses
{
    public class ConstructorlessTestClass : IConstructorlessTestClass
    {
        private string _classdescription = "NoConstructor";

        public string ClassDescription
        {
            get { return _classdescription; }
            set { _classdescription = value; }
        }

    }
}   
