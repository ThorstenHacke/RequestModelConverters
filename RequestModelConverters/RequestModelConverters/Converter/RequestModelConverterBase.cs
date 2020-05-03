using RequestModelConverters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RequestModelConverters.Converter
{
    public abstract class RequestModelConverterBase<T> : IRequestModelConverter<T>
    {
        public T ConvertRequestModel(object obj)
        {
            Type t = obj.GetType();
            IEnumerable<PropertyInfo> properties = GetNotNullFlaggedProperties(obj, t);
            List<string> parameters = GetPropertyValues(obj, properties);
            return ConvertParameter(parameters);
        }

        protected abstract T ConvertParameter(List<string> parameters);

        protected  IEnumerable<PropertyInfo> GetNotNullFlaggedProperties(object obj, Type t)
        {
            IEnumerable<PropertyInfo> properties = t.GetProperties();
            properties = properties.Where(p => p.GetCustomAttribute<RequestParameterAttribute>() != null);
            properties = properties.Where(p => p.GetValue(obj, null) != null);
            return properties;
        }

        protected List<string> GetPropertyValues(object obj, IEnumerable<PropertyInfo> properties)
        {
            List<string> parameters = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                RequestParameterAttribute uriParameter = property.GetCustomAttribute<RequestParameterAttribute>();
                var value = uriParameter.GetPropertyValue(property, obj);
                if (!string.IsNullOrEmpty(value))
                {
                    parameters.Add(uriParameter.ParameterName + "=" + value);
                }
            }

            return parameters;
        }


    }
}
