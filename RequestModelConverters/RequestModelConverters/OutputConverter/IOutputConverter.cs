using System;
using System.Collections.Generic;
using System.Text;

namespace RequestModelConverters.OutputConverter
{
    public interface IOutputConverter<TOutput>
    {
        TOutput ConvertParameter(Dictionary<string, string> parameters);
    }
}
