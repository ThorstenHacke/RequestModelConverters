using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RequestModelConverters.Tests
{
    public class RequestParameterAttributeTests
    {
        [TestCase("TestValue", null,false, "TestValue")]
        [TestCase("TestValue", null,true, "TESTVALUE")]
        [TestCase("TestValue", "TestValue",false, "")]
        [TestCase("TestValue", "TESTVALUE", true, "TESTVALUE")]//TO discuss: Should the Uppercasing be before Value test or after?

        public void GetPropertyValueTest(string propertyReturnValue, string ignoreValue, bool uppercase, string expected )
        {
            object emptyTestObject = new object();
            Mock<PropertyInfo> propertyInfoMock = new Mock<PropertyInfo>();
            propertyInfoMock.Setup(p => p.GetValue(emptyTestObject, null)).Returns(propertyReturnValue);
            RequestParameterAttribute attr = new RequestParameterAttribute("Test", ignoreValue,uppercase);
            var actual = attr.GetPropertyValue(propertyInfoMock.Object, emptyTestObject);
            Assert.AreEqual(expected, actual);
        }

    }
}
