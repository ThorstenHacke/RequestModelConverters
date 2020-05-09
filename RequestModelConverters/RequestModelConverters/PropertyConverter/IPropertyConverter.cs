using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RequestModelConverters.PropertyConverter
{
    public interface IPropertyConverter<T> where T : Attribute
    {
        KeyValuePair<string, string> GetEntryFromProperty(object obj, PropertyInfo property);
       
    }
}
