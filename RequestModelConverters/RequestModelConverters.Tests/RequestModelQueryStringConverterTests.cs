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
            RequestParametersQueryStringConverter converter = new RequestParametersQueryStringConverter();
            var actual = converter.ConvertRequestModel(new SimpleTestModel());
            Assert.AreEqual(SimpleTestModel.ExpectedString, actual);
        }

        [Test]
        public void TestComplexModel()
        {
            RequestParametersQueryStringConverter converter = new RequestParametersQueryStringConverter();
            var actual = converter.ConvertRequestModel(new ComplexTestModel());
            Assert.AreEqual(ComplexTestModel.ExpectedString, actual);
        }

        [Test]
        public void TestEmptyModel()
        {
            RequestParametersQueryStringConverter converter = new RequestParametersQueryStringConverter();
            var actual = converter.ConvertRequestModel(new object());
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        public void TestDetailedModel()
        {
            RequestParametersQueryStringConverter converter = new RequestParametersQueryStringConverter();
            var actual = converter.ConvertRequestModel(new DetailedTestModel());
            Assert.AreEqual(DetailedTestModel.ExpectedValue, actual);
        }
    }
}