using RequestModelConverters.Attributes;

namespace RequestModelConverters.Tests.Data
{
    public class SimpleTestModel
    {
        [RequestParameter("POne")]
        public string ParameterOne => "One";

        public static string ExpectedString = "?POne=One";
    }
    public class ComplexTestModel
    {
        [RequestParameter("POne")]
        public string ParameterOne => "One";
        [RequestParameter("PTWO", uppercase:true)]
        public string ParameterTWO => "two";
        [RequestParameter("PThree","Test")]
        public string ParameterThree => "Test";

        public static string ExpectedString = "?POne=One&PTWO=TWO";
    }
}
