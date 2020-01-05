using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.Extensions
{
    public static class StringExtensions
    {
        public static string ToJs(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToLower();
            }

            return str[0].ToString().ToLower() + str.Substring(1);
        }
    }
}
