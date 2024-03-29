﻿using System.Globalization;

namespace Common.Application;

public static class Format
{
    public const string DateFormat = "yyyy.MM.dd";
    public const string TimeFormat = "HH:mm";
    public const string DateTimeFormat = "yyyy.MM.dd. HH:mm:ss";
    public const string DateTimeFormatUtc = "yyyy.MM.ddTHH:mm:ss";
    public const string YearFormat = "yyyy";

    private static readonly NumberFormatInfo FormatProvider = new NumberFormatInfo { NumberDecimalSeparator = ",", NumberGroupSeparator = " " };

    private static readonly IDictionary<string, string> CurrencySmbols = new Dictionary<string, string> { { "WUD", "₩" }, { "USD", "$" }, { "EUR", "€" }, { "GBP", "£" }, { "CHF", "₣" }, { "JPY", "¥" }, { "AUD", "A$" }, { "CAD", "C$" } };

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

    public static string FormatDate(this DateTime? value)
    {
        if (value == null) return "Unknown";
        return value.Value.ToString(DateFormat);
    }

    public static string FormatTime(this DateTime? value)
    {
        if (value == null) return "Unknown";
        return value.Value.ToString(TimeFormat);
    }

    public static string FormatDate(this DateTime value)
    {
        return value.ToString(DateFormat);
    }

    public static string FormatTime(this DateTime value)
    {
        return value.ToString(TimeFormat);
    }
}