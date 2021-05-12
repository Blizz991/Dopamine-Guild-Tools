using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Infrastructure
{
    public static class StringHelpers
    {
        // <summary>
        /// Limit the length of a string and/or strip html tags
        /// </summary>
        /// <param name="text">The string to limit the length of</param>
        /// <param name="max_length">Maxlength of string, defaults to 250</param>
        /// <param name="strip_html">Defines whether the method should remove html tags</param>
        /// <returns>Limited string - html stripped if asked for</returns>
        public static string LimitString(this string text, int max_length = 250, bool strip_html = false)
        {
            if (strip_html)
            {
                text = StripTagsRegex(text);
            }
            if (text.Length > max_length)
            {
                int limit = text.Substring(0, max_length).LastIndexOf(' ');
                return text.Substring(0, limit) + "...";
            }
            else
            {
                return text;
            }
        }

        public static string EscapeString(this string text)
        {
            return text.Replace("'", "\'");
        }

        /// <summary>
        /// Remove HTML tags from string using Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        public static string FormatNewlinesForDisplay(this string text, string default_text = "N/A")
        {
            if (text == "")
            {
                return default_text;
            }
            else
            {
                return Regex.Replace(text, @"\r\n?|\n", "<br />");
            }
        }

        public static string RemoveLineEndings(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        private static string Base64URLEncode(string stringToEncode)
        {
            return stringToEncode.Replace('+', '-').Replace('/', '_');
        }

        private static string Base64URLDecode(string stringToDecode)
        {
            return stringToDecode.Replace('-', '+').Replace('_', '/');
        }

        public static string CreateSlug(this string text)
        {
            //string slug = text.Replace(" ", "-").ToLower();

            return text.Replace(" ", "-").ToLower();
        }

        public static string CapitalizeFirstLetter(this string text)
        {
            if (String.IsNullOrEmpty(text)) return text;
            if (text.Length == 1) return text.ToUpper();
            return text.Remove(1).ToUpper() + text.Substring(1);
        }

        public static string ToWowClassCssClass(this string text)
        {
            return text.Replace(" ", "-").ToLower() + "-text";
        }
    }
}
