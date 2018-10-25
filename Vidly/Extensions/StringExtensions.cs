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
    }
}