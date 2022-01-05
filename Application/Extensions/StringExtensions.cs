using System;
using System.Linq;

namespace Common.Application
{
    public static class StringExtensions
    {
        public static string Capitalize(this string original)
        {
            return char.ToUpper(original.First()) + original.Substring(1).ToLower();
        }
    }
}