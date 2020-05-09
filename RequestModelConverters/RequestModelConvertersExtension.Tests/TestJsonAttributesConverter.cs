using Newtonsoft.Json;
using NUnit.Framework;
using RequestModelConverters.Converter;
using RequestModelConverters.OutputConverter;
using RequestModelConvertersExtension.Tests.Examples.Json;
using System;

namespace RequestModelConvertersExtension.Tests
{
    public class Tests
    {
        private RequestModelConverter<string, JsonPropertyAttribute> converter;

        [SetUp]
        public void Setup()
        {
            converter = new RequestModelConverter<string, JsonPropertyAttribute>(new JsonParameterConverter(), new QueryStringConverter());
        }

        [Test]
        public void TestSimpleModelWithJsonPropertyAttribute()
        {
            var actual = converter.ConvertRequestModel(new Model());
            Assert.AreEqual("?ValueOne=ValueOne", actual);
        }

        [Test]
        public void TestComplexModelWithConverterOnProperty()
        {
            var actual = converter.ConvertRequestModel(new ModelComplexOne());
            Assert.AreEqual(ModelComplexOne.ExpectedValue, actual);
        }

        [Test]
        public void TestBadModel()
        {
            Assert.Throws(typeof(ArgumentException), () => converter.ConvertRequestModel(new BadModel()));
        }
    }
}