using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Common.Application.Extensions
{
    public static class FormatExtensions
    {
        private static readonly NumberFormatInfo FormatProvider = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

        private static readonly IDictionary<string, string> CurrencySmbols;

        static FormatExtensions()
        {
            FormatProvider.NumberDecimalSeparator = ",";
            FormatProvider.NumberGroupSeparator = " ";

            CurrencySmbols = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(c => !c.IsNeutralCulture).Select(
                culture =>
                {
                    try { return new RegionInfo(culture.Name); }
                    catch { return null; }
                }
                ).Where(ri => ri != null).GroupBy(ri => ri.ISOCurrencySymbol).ToDictionary(x => x.Key, x => x.First().CurrencySymbol);
        }

        private static string GetCurrencySymbol(string ISOCurrencySymbol)
        {
            if (ISOCurrencySymbol == null) return "";
            CurrencySmbols.TryGetValue(ISOCurrencySymbol, out string symbol);
            return symbol;
        }

        public static string FormatCurrency(this decimal value, string ISOCurrencySymbol, bool showSpecialValuesAsString = false)
        {
            if (showSpecialValuesAsString && value == 0) return "Unknown";
            if (showSpecialValuesAsString && value == decimal.MaxValue) return "Infinity";
            return GetCurrencySymbol(ISOCurrencySymbol) + string.Format(FormatProvider, " {0:N2}", value);
        }

        public static string FormatCurrency(this long value, string ISOCurrencySymbol, bool showSpecialValuesAsString = false)
        {
            if (showSpecialValuesAsString && value == 0) return "Unknown";
            if (showSpecialValuesAsString && value == long.MaxValue) return "Infinity";
            return GetCurrencySymbol(ISOCurrencySymbol) + string.Format(FormatProvider, " {0:N0}", value);
        }

        public static string FormatPercent(this decimal value)
        {
            return string.Format(FormatProvider, "{0:F2}", value * 100) + " %";
        }

        public static string FormatDecimal(this decimal value)
        {
            return string.Format(FormatProvider, "{0:F2}", value);
        }

        public static string FormatInteger(this decimal value)
        {
            return string.Format(FormatProvider, "{0:F0}", value);
        }
    }
}
