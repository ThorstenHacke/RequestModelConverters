using RequestModelConverters.Attributes;
using RequestModelConverters.OutputConverter;
using RequestModelConverters.PropertyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RequestModelConverters.Converter
{
    public class RequestModelConverter<TOutput,TAttribute> : IRequestModelConverter<TOutput>
        where TAttribute : Attribute
    {
        private readonly IPropertyConverter<TAttribute> propertyConverter;
        private readonly IOutputConverter<TOutput> outputConverter;

        public RequestModelConverter(IPropertyConverter<TAttribute> propertyConverter, IOutputConverter<TOutput> outputConverter)
        {
            this.propertyConverter = propertyConverter;
            this.outputConverter = outputConverter;
        }

        public TOutput ConvertRequestModel(object obj)
        {
            Type t = obj.GetType();
            IEnumerable<PropertyInfo> properties = GetNotNullFlaggedProperties(obj, t);
            Dictionary<string, string> parameters = GetPropertyValues(obj, properties);
            return outputConverter.ConvertParameter(parameters);
        }

        private IEnumerable<PropertyInfo> GetNotNullFlaggedProperties(object obj, Type t)
        {
            IEnumerable<PropertyInfo> properties = t.GetProperties();
            properties = properties.Where(p => p.GetCustomAttribute<TAttribute>() != null);
            properties = properties.Where(p => p.GetValue(obj, null) != null);
            return properties;
        }

        private Dictionary<string, string> GetPropertyValues(object obj, IEnumerable<PropertyInfo> properties)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (PropertyInfo property in properties)
            {
                var data = propertyConverter.GetEntryFromProperty(obj, property);
                parameters.Add(data.Key, data.Value);
            }

            return parameters;
        }

        


    }
}
