using System;
using Syncfusion.Blazor.Charts;

namespace Common.Web
{
    public static class SyncfusionExtensions
    {
        public static string ToFormat(this RangeIntervalType intervalType)
        {
            return intervalType switch
            {
                RangeIntervalType.Auto => null,
                RangeIntervalType.Years => "yyyy",
                RangeIntervalType.Quarter => "yyyy.MMMM",
                RangeIntervalType.Months => "MMMM",
                RangeIntervalType.Weeks => "MMMM",
                RangeIntervalType.Days => "MM.dd",
                RangeIntervalType.Hours => "hh",
                RangeIntervalType.Minutes => "hh.mm",
                RangeIntervalType.Seconds => "mm.ss",
                _ => throw new NotImplementedException(),
            };
        }
    }
}