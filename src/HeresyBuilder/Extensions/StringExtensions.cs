using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeresyBuilder.Extensions
{
    public static class StringExtensions
    {
        public static string SplitCamelCase(this string input)
        {
            return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
        }
    }
}
