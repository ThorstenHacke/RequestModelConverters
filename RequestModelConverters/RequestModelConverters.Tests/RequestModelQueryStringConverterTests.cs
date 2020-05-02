using NUnit.Framework;
using RequestModelConverters.Converter;
using RequestModelConverters.Tests.Data;

namespace RequestModelQueryStringConverters.Tests
{
    public class RequestModelQueryStringConverterTests
    {
        [Test]
        public void Test1()
        {
            RequestModelQueryStringConverter converter = new RequestModelQueryStringConverter();
            var actual = converter.ConvertRequestModel(new SimpleTestModel());
            Assert.AreEqual(SimpleTestModel.ExpectedString, actual);
        }

        [Test]
        public void TestComplexModel()
        {
            RequestModelQueryStringConverter converter = new RequestModelQueryStringConverter();
            var actual = converter.ConvertRequestModel(new ComplexTestModel());
            Assert.AreEqual(ComplexTestModel.ExpectedString, actual);
        }
    }
}