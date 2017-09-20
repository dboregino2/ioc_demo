using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOControlFreak.Tests.TestClasses
{
    public class TestObject1
    {
        public TestObject1()
        {

        }
        public TestObject1(string name)
        {
            Name = name;
        }
        public TestObject1(int id)
        {
            Id = Id;
        }
        public TestObject1(string name, int id)
        {
            Name = name;
            Id = Id;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class TestObject2
    {
        public TestObject2(string name, int id)
        {
            Name = name;
            Id = Id;
        }
        public TestObject2()
        {

        }
        public TestObject2(int id)
        {
            Id = Id;
        }
        public TestObject2(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }


}
