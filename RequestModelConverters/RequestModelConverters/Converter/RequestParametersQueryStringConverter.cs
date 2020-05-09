using RequestModelConverters.Attributes;
using RequestModelConverters.OutputConverter;
using RequestModelConverters.PropertyConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestModelConverters.Converter
{
    public class RequestParametersQueryStringConverter : RequestModelConverter<string, RequestParameterAttribute>
    {
        public RequestParametersQueryStringConverter() : base(new RequestParameterConverter(), new QueryStringConverter())
        {
        }
    }
}
