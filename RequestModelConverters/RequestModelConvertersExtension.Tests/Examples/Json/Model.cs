using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestModelConvertersExtension.Tests.Examples.Json
{
    public class Model
    {
        [JsonProperty]
        public string ValueOne { get; set; } = "ValueOne";
    }

    public class ModelComplexOne
    {
        [JsonProperty("Hallo")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime ValueOne { get; set; } = new DateTime(2020,05,10);

        public static string ExpectedValue = "?Hallo=2020-05-10";
    }

    public class BadModel
    {
        [JsonProperty("Hallo")]
        [JsonConverter(typeof(string))]//This is not a Converter
        public DateTime ValueOne { get; set; } = new DateTime(2020, 05, 10);

        public static string ExpectedValue = "?Hallo=2020-05-10";
    }

    public class JsonDateTimeConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Creates a new instance of <see cref="JsonDateTimeConverter"/>
        /// </summary>
        public JsonDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }

}
