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

        public static string MD5_Crypt(this string val)
        {
            string returnvalue = "";
            System.Security.Cryptography.MD5CryptoServiceProvider provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            returnvalue = BitConverter.ToString(provider.ComputeHash(System.Text.Encoding.ASCII.GetBytes(val)));
            returnvalue = returnvalue.Replace("-", null);
            return returnvalue;
        }

        public static string MD5_DeCrypt(this string val)
        {
            string returnvalue = "";
            System.Security.Cryptography.MD5CryptoServiceProvider provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            returnvalue  = System.Text.Encoding.ASCII.GetString(provider.ComputeHash(Convert.FromBase64String(val)));
            return returnvalue;
        }

    }
}