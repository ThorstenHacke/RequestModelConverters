using RequestModelConverters.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RequestModelConverters.PropertyConverter
{
    public class RequestParameterConverter : IPropertyConverter<RequestParameterAttribute>
    {
        public KeyValuePair<string, string> GetEntryFromProperty(object obj, PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<RequestParameterAttribute>();
            var value = attribute.GetPropertyValue(property, obj);
            var retVal = new KeyValuePair<string, string>(attribute.ParameterName, value);
            return retVal;
        }
    }
}
