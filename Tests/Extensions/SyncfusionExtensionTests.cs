using System;
using Common.Application;
using Common.Backend;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Syncfusion.Blazor.Charts;

namespace Common.Tests.Models
{
    public class SyncfusionExtensionTests
    {
        [Fact]
        public void LabelFormatTest()
        {
            // Arrange
            var date = new DateTime(2016, 2, 3, 4, 5, 6);

            //Assert
            Assert.Null(RangeIntervalType.Auto.ToFormat());

            Assert.Equal("yyyy", RangeIntervalType.Years.ToFormat());
            Assert.Equal("2016", date.ToString(RangeIntervalType.Years.ToFormat()));
        }
    }

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