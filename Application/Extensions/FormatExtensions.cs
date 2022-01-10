using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Common.Application
{
    public static class FormatExtensions
    {
        private static readonly NumberFormatInfo FormatProvider = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

        private static readonly IDictionary<string, string> CurrencySmbols;

        public static string DateFormat { get; } = "yyyy.MM.dd.";

        public static string TimeFormat { get; } = "HH:mm";

        public static string DateTimeFormat { get; } = "yyyy.MM.dd. HH:mm:ss";

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
            if (ISOCurrencySymbol == "WUD") return "₩" + string.Format(FormatProvider, " {0:N2}", value);
            return GetCurrencySymbol(ISOCurrencySymbol) + string.Format(FormatProvider, " {0:N2}", value);
        }

        public static string FormatCurrency(this decimal value, string ISOCurrencySymbol, int decimalPlaces)
        {
            return GetCurrencySymbol(ISOCurrencySymbol) + string.Format(FormatProvider, " {0:N" + decimalPlaces + "}", value);
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
