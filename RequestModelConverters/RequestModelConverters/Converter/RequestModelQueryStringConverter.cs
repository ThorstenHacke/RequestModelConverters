using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RequestModelConverters.Converter
{
    public class RequestModelQueryStringConverter : IRequestModelConverter<string>
    {
        public string ConvertRequestModel(object obj)
        {
            Type t = obj.GetType();
            IEnumerable<PropertyInfo> properties = t.GetProperties();
            properties = properties.Where(p => p.GetCustomAttribute<RequestParameterAttribute>() != null);
            properties = properties.Where(p => p.GetValue(obj, null) != null);
            List<string> parameters = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                RequestParameterAttribute uriParameter = property.GetCustomAttribute<RequestParameterAttribute>();
                string queryValue = property.GetValue(obj).ToString();
                if (uriParameter.IgnoreValue != null && uriParameter.IgnoreValue.Equals(queryValue))
                {
                    continue;
                }
                if (uriParameter.Uppercase)
                {
                    queryValue = queryValue.ToUpper();
                }
                parameters.Add(uriParameter.ParameterName + "=" + queryValue);
            }
            return "?" + string.Join("&", parameters);
        }
    }
}
