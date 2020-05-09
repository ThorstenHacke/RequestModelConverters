using RequestModelConverters.Attributes;
using RequestModelConverters.OutputConverter;
using RequestModelConverters.PropertyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RequestModelConverters.OutputConverter
{
    public class QueryStringConverter : IOutputConverter<string>
    {
        public string ConvertParameter (Dictionary<string, string> parameters)
        {
            if (parameters.Count == 0)
            {
                return string.Empty;
            }
            return "?" + string.Join("&", parameters.Select(p => string.IsNullOrEmpty(p.Value)?null: p.Key+"="+p.Value).Where(p => p != null));
        }

        
    }
}
