using IOControlFreak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static IOControlFreak.Enums;

namespace IOControlFreak.Tests
{
    public class RegistrationOptionsTests
    {
        [Fact]
        public void RegistrationOptions_default_lifecycle_is_transient()
        {
            //Arrange
            var opts = new RegistrationOptions();

            //Act

            //Assert
            Assert.True(opts.LifeCycle == LifeCycleType.Transient);
        }
        [Fact]
        public void RegistrationOptions_default_allowmultiple_is_false()
        {
            //Arrange
            var opts = new RegistrationOptions();
            //Act
            //Assert
            Assert.False(opts.AllowMultiple);
        }
    }
}
