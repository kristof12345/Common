using System.Linq;

namespace Common.Application;

public static class StringExtensions
{
    public static string Capitalize(this string original)
    {
        return char.ToUpper(original.First()) + original[1..].ToLower();
    }
}
