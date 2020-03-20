using ComparisonGenerator.Core.Tests.Example;
using NFluent;
using NUnit.Framework;
using System;
using ComparisonGenerator.Core.Reflection;


namespace ComparisonGenerator.Core.Tests.Reflection
{
    public class MoreReflectionShould
    {
        [Test]
        public void ImplementsOpenGenericInterface_Throw_ArgumentNullException_When_Provided_Type_Is_Null()
        {
            Type nullType = null;
            Check.ThatCode(() => nullType.ImplementsOpenGenericInterface(typeof(ISomeGenericInterface<>)))
                .Throws<ArgumentNullException>();
        }

        [Test]
        public void ImplementsOpenGenericInterface_Should_Throw_ArgumentNullException_When_Provided_Type_Is_Null()
        {
            Type someType = typeof(SomeClass);
            Check.ThatCode(() => someType.ImplementsOpenGenericInterface(null))
                .Throws<ArgumentNullException>();
        }

        [Test]
        [TestCase(typeof(SomeClass))]
        [TestCase(typeof(ISomeNonGenericInterface))]
        [TestCase(typeof(int))]
        public void ImplementsOpenGenericInterface_Throw_Argument_Exception_When_Provided_Type_Is_Invalid(Type invalidType)
        {
            Type someType = typeof(SomeClass);
            Check.ThatCode(() => someType.ImplementsOpenGenericInterface(invalidType))
                .Throws<ArgumentException>();
        }

        [Test]
        [TestCase(typeof(SomeClassImplementingSomeGenericInterface), typeof(ISomeGenericInterface<>))]
        [TestCase(typeof(SomeClassImplementingSomeOtherGenericInterface), typeof(ISomeOtherGenericInterface<>))]
        public void ImplementsOpenGenericInterface_Return_True_When_Provided_Type_Implements_Interface(Type testedType, Type typeImplementingInterface)
        {
            Check.That(testedType.ImplementsOpenGenericInterface(typeImplementingInterface))
                .IsTrue();
        }

        [Test]
        [TestCase(typeof(SomeClassImplementingSomeGenericInterface), typeof(ISomeOtherGenericInterface<>))]
        [TestCase(typeof(SomeClassImplementingSomeOtherGenericInterface), typeof(ISomeGenericInterface<>))]
        public void ImplementsOpenGenericInterface_Return_False_When_Provided_Type_Does_Not_Implement_Interface(Type testedType, Type typeNotImplementingInterface)
        {
            Check.That(testedType.ImplementsOpenGenericInterface(typeNotImplementingInterface))
                .IsFalse();
        }



        [Test]
        public void GetTypeImplementingOpenGenericInterface_Throw_ArgumentNullException_When_Provided_Type_Is_Null()
        {
            Type nullType = null;
            Check.ThatCode(() => nullType.GetTypeImplementingOpenGenericInterface(typeof(ISomeGenericInterface<>)))
                .Throws<ArgumentNullException>();
        }

        [Test]
        public void GetTypeImplementingOpenGenericInterface_Should_Throw_ArgumentNullException_When_Provided_Type_Is_Null()
        {
            Type someType = typeof(SomeClass);
            Check.ThatCode(() => someType.GetTypeImplementingOpenGenericInterface(null))
                .Throws<ArgumentNullException>();
        }

        [Test]
        [TestCase(typeof(SomeClass))]
        [TestCase(typeof(ISomeNonGenericInterface))]
        [TestCase(typeof(int))]
        public void GetTypeImplementingOpenGenericInterface_Throw_Argument_Exception_When_Provided_Type_Is_Invalid(Type invalidType)
        {
            Type someType = typeof(SomeClass);
            Check.ThatCode(() => someType.GetTypeImplementingOpenGenericInterface(invalidType))
                .Throws<ArgumentException>();
        }

        [Test]
        [TestCase(typeof(SomeClass), typeof(ISomeGenericInterface<>))]
        [TestCase(typeof(SomeClassImplementingSomeOtherGenericInterface), typeof(ISomeGenericInterface<>))]
        public void GetTypeImplementingOpenGenericInterface_Throws_ArgumentException_When_Prodived_Type_Does_Not_Implement_Provided_Interface(Type testedType, Type notImplementedType)
        {
            Check.ThatCode(() => testedType.GetTypeImplementingOpenGenericInterface(notImplementedType))
                .Throws<ArgumentException>();
        }

        [Test]
        [TestCase(typeof(SomeClassImplementingSomeGenericInterface), typeof(ISomeGenericInterface<>), typeof(int))]
        [TestCase(typeof(SomeGenericClassImplementingSomeGenericInterface<string>), typeof(ISomeGenericInterface<>), typeof(string))]
        public void GetTypeImplementingOpenGenericInterface_Returns_Expected_Type_When_Prodived_Type_Does_Not_Implement_Provided_Interface(Type testedType, Type ogiType, Type expectedResult)
        {
            Check.That(testedType.GetTypeImplementingOpenGenericInterface(ogiType))
                .IsEqualTo(expectedResult);
        }
    }
}
