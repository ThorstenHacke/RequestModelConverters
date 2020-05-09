using Newtonsoft.Json;
using RequestModelConverters.PropertyConverter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RequestModelConvertersExtension.Tests.Examples.Json
{
    public class JsonParameterConverter : IPropertyConverter<JsonPropertyAttribute>
    {
        public KeyValuePair<string, string> GetEntryFromProperty(object obj, PropertyInfo property)
        {
            string propertyName = GetPropertyName(property);
            string value = GetPropertyValue(obj, property);
            return new KeyValuePair<string, string>(propertyName, value);
        }

        private static string GetPropertyValue(object obj, PropertyInfo property)
        {
            JsonSerializerSettings serializerSettings = GetSerializerSettings(property);

            var value = JsonConvert.SerializeObject(property.GetValue(obj), serializerSettings);
            value = value.Replace("\"", string.Empty);
            return value;
        }

        private static JsonSerializerSettings GetSerializerSettings(PropertyInfo property)
        {
            var converterAttribute = property.GetCustomAttribute<JsonConverterAttribute>();
            var serializerSettings = new JsonSerializerSettings();
            if (converterAttribute != null)
            {
                try
                {
                    serializerSettings.Converters = new List<JsonConverter> {
                    Activator.CreateInstance(converterAttribute.ConverterType,converterAttribute.ConverterParameters) as JsonConverter
                    };
                }catch(Exception ex)
                {
                    throw new ArgumentException("Can not create converter", ex);
                }
            }

            return serializerSettings;
        }

        private static string GetPropertyName(PropertyInfo property)
        {
            var propertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            string propertyName = propertyAttribute.PropertyName ?? property.Name;
            return propertyName;
        }
    }
}
