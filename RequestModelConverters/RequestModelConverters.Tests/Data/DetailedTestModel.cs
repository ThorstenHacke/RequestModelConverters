using RequestModelConverters.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RequestModelConverters.Tests.Data
{
    public class DetailedTestModel
    {
        [Required]
        [RequestParameter("StringA")]
        public string StringA { get; set; } = "AAA";

        [Required]
        [RequestParameter("StringB")]
        public string StringB { get; set; } = "BBB";

        [RequestParameter("start", formatString:"yyyy-MM-dd")]
        public DateTime Start { get; set; } = new DateTime(2020,05,07);

        [RequestParameter("end", formatString: "yyyy-MM-dd")]
        public DateTime End { get; set; } = new DateTime(2020, 11, 07);

        [RequestParameter("nullableInt")]
        public int? NullableInt { get; set; }

        [RequestParameter("locale")]
        public string Locale { get; set; } = "de-DE";

        [RequestParameter("NullableIntWithValue")]
        public int? NullableIntWithValue { get; set; } = 7;


        public static string ExpectedValue = "?StringA=AAA&StringB=BBB&start=2020-05-07&end=2020-11-07&locale=de-DE&NullableIntWithValue=7";
    }
}
