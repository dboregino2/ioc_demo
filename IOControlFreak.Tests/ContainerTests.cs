using Xunit;
using System;
using IOControlFreak.Models;
using static IOControlFreak.Enums;
using IOControlFreak;
using IOControlFreak.Tests.Interfaces;
using IOControlFreak.Tests.TestClasses;
using IOControlFreak.Exceptions;

namespace IoControlFreak.Tests
{

    public class ContainerTests
    {
        private CFContainer _commonTestContainer;

        public ContainerTests()
        {
            _commonTestContainer = new CFContainer();
            _commonTestContainer.Register<ITransientTestClass, TransientTestClass>();
            _commonTestContainer.Register<ISingletonTestClass, SingletonTestClass>(LifeCycleType.Singleton);
            _commonTestContainer.Register<IConstructorInjectedTestClass, ConstructorInjectedTestClass>();
            _commonTestContainer.Register<INestedInjectionTestClass, NestedInjectionTestClass>();
            _commonTestContainer.Register<IConstructorlessTestClass, ConstructorlessTestClass>();
        }

        [Fact]
        public void Container_registers_types()
        {
            //Arrange        
            var testContainer = new CFContainer();
            //Act
            testContainer.Register<ITransientTestClass, TransientTestClass>();
            ITransientTestClass resolvedClass = testContainer.Resolve<ITransientTestClass>();
            //Assert
            Assert.True(resolvedClass != null);
            Assert.IsType(typeof(TransientTestClass), resolvedClass);
        }

        [Fact]
        public void Container_manages_lifecycletypes()
        {
            //Arrange        
            var testContainer = new CFContainer();
            //Act
            testContainer.Register<ITransientTestClass, TransientTestClass>(LifeCycleType.Transient);
            testContainer.Register<ISingletonTestClass, SingletonTestClass>(LifeCycleType.Singleton);
            ITransientTestClass resolvedClass = testContainer.Resolve<ITransientTestClass>();
            ITransientTestClass resolvedClass2 = testContainer.Resolve<ITransientTestClass>();
            ISingletonTestClass resolvedSingleton = testContainer.Resolve<ISingletonTestClass>();
            ISingletonTestClass resolvedSingleton2 = testContainer.Resolve<ISingletonTestClass>();
            //Assert
            Assert.NotSame(resolvedClass, resolvedClass2);
            Assert.Same(resolvedSingleton, resolvedSingleton2);
        }

        [Fact]
        public void registered_objects_are_transient_by_Default()
        {
            //Arrange        
            var testContainer = new CFContainer();
            //Act
            testContainer.Register<ITransientTestClass, TransientTestClass>();
            ITransientTestClass resolvedClass = testContainer.Resolve<ITransientTestClass>();  
            ITransientTestClass resolvedClass2 = testContainer.Resolve<ITransientTestClass>();
            //Assert
            Assert.NotSame(resolvedClass, resolvedClass2);
        }

        [Fact]
        public void resolving_unregistered_types_throws_exception()
        {
            //Arrange        
            var testContainer = new CFContainer();
            //Act

            //Assert
            TypeNotRegisteredException ex = Assert.Throws<TypeNotRegisteredException>(() =>
            {
                ITransientTestClass resolvedClass = testContainer.Resolve<ITransientTestClass>();
            });
            
        }

        [Fact]
        public void registering_duplicate_types_throws_exception()
        {
            //Arrange        
            var testContainer = new CFContainer();
            //Act
            testContainer.Register<ITransientTestClass, TransientTestClass>();
            //Assert
            TypeAlreadyRegisteredException ex = Assert.Throws<TypeAlreadyRegisteredException>(() =>
            {
                testContainer.Register<ITransientTestClass, TransientTestClass>();
            });

        }

        [Fact]
        public void registering_invalid_interfaces_type_pairs_throws_exception()
        {
            //Arrange        
            var testContainer = new CFContainer();
            //Act
        
            //Assert
            InvalidTypeRegistrationException ex = Assert.Throws<InvalidTypeRegistrationException>(() =>
            {
                testContainer.Register<ISingletonTestClass, TransientTestClass>();
            });

        }

        [Fact]
        public void Container_resolves_constructor_dependencies()
        {
            //Arrange        

            //Act
            IConstructorInjectedTestClass paramTest = _commonTestContainer.Resolve<IConstructorInjectedTestClass>();
            //Assert
            Assert.NotNull(paramTest);
            Assert.NotNull(paramTest.SingletonProperty);
            Assert.NotNull(paramTest.TransientProperty);
            Assert.IsType(typeof(ConstructorInjectedTestClass), paramTest);
            Assert.IsType(typeof(SingletonTestClass), paramTest.SingletonProperty);
            Assert.IsType(typeof(TransientTestClass), paramTest.TransientProperty);
        }

        [Fact]
        public void Container_resolves_nested_constructor_dependencies()
        {
            //Arrange        

            //Act
            INestedInjectionTestClass nestedTest = _commonTestContainer.Resolve<INestedInjectionTestClass>();

         
            //Assert
           
            Assert.NotNull(nestedTest);
            Assert.NotNull(nestedTest.NestedInstance);
            Assert.NotNull(nestedTest.NestedInstance.SingletonProperty);
            Assert.NotNull(nestedTest.NestedInstance.TransientProperty);
            Assert.IsType(typeof(NestedInjectionTestClass), nestedTest);
            Assert.IsType(typeof(ConstructorInjectedTestClass), nestedTest.NestedInstance);
            Assert.IsType(typeof(SingletonTestClass), nestedTest.NestedInstance.SingletonProperty);
            Assert.IsType(typeof(TransientTestClass), nestedTest.NestedInstance.TransientProperty);
        }


    }
}
