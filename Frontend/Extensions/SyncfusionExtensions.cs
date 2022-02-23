using System;
using Syncfusion.Blazor.Charts;

namespace Common.Web
{
    public static class SyncfusionExtensions
    {
        public static string ToFormat(this IntervalType intervalType)
        {
            return intervalType switch
            {
                IntervalType.Auto => "yyyy.MM.dd",
                IntervalType.Years => "yyyy",
                IntervalType.Months => "MMMM",
                IntervalType.Days => "yyyy.MM.dd",
                IntervalType.Hours => "hh",
                IntervalType.Minutes => "hh:mm",
                IntervalType.Seconds => "hh:mm:ss",
                _ => throw new NotImplementedException(),
            };
        }

        public static string ToFormat(this RangeIntervalType intervalType)
        {
            return intervalType switch
            {
                RangeIntervalType.Auto => "MMMM",
                RangeIntervalType.Years => "yyyy",
                RangeIntervalType.Quarter => "yyyy.MMMM",
                RangeIntervalType.Months => "MMMM",
                RangeIntervalType.Weeks => "MMMM",
                RangeIntervalType.Days => "MM.dd",
                RangeIntervalType.Hours => "hh",
                RangeIntervalType.Minutes => "hh:mm",
                RangeIntervalType.Seconds => "hh:mm:ss",
                _ => throw new NotImplementedException(),
            };
        }
    }
}