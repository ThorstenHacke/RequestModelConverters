using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RequestModelConverters.Converter
{
    public class RequestModelQueryStringConverter : RequestModelConverterBase<string>
    {
        protected override string ConvertParameter (List<string> parameters)
        {
            if (parameters.Count == 0)
            {
                return string.Empty;
            }
            return "?" + string.Join("&", parameters);
        }

    }
}
