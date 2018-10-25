using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Extensions
{
    public static class StringExtensions
    {
        public static string Trim(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return "";

            return val.Trim();

        }

        public static string ToCamelCase(this string val)
        {

            return (val);
        }

        public static string ToFirstLetterUpperCase(this string val)
        {

            return (val);
        }

    }
}