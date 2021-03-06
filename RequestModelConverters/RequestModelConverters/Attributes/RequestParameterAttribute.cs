﻿using System;
using System.Reflection;

namespace RequestModelConverters.Attributes
{
    public class RequestParameterAttribute : Attribute
    {
        /// <summary>
        /// Propertys with this attribute are converted by IRequestModelConverter
        /// </summary>
        /// <param name="parameterName">Parametername in the query string</param>
        /// <param name="ignoreValue">If the return value of the property equals teh given value the parameter is ignored (not added to the string)</param>
        /// <param name="uppercase">set to true if the value should be casted to uppercase</param>
        public RequestParameterAttribute(string parameterName, string ignoreValue = null, bool uppercase = false, string formatString = null)
        {
            Uppercase = uppercase;
            ParameterName = parameterName;
            IgnoreValue = ignoreValue;
            FormatString = formatString;
        }

        /// <summary>
        /// Parametername in the query string
        /// </summary>
        public string ParameterName { get; }
        /// <summary>
        /// If the return value of the property equals teh given value the parameter is ignored (not added to the string)
        /// </summary>
        public string IgnoreValue { get; }

        /// <summary>
        /// True if value is always converted to Uppercase for URI
        /// </summary>
        public bool Uppercase { get; }

        /// <summary>
        /// Used to format the string output of the property
        /// </summary>
        public string FormatString { get; set; }

        public virtual string GetPropertyValue(PropertyInfo property, object obj)
        {
            object propertyValue = property.GetValue(obj);

            string propertyString = propertyValue.ToString();
            if (!string.IsNullOrEmpty(FormatString))
            {
                propertyString = string.Format("{0:" + FormatString + "}", propertyValue);
            }
            if (IgnoreValue != null && IgnoreValue.Equals(propertyValue))
            {
                return string.Empty;
            }
            if (Uppercase)
            {
                propertyString = propertyString.ToUpper();
            }
            return propertyString;
        }
    }
}
