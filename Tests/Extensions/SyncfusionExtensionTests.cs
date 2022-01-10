using System;
using Common.Application;
using Common.Backend;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor.Charts;
using Common.Web;
using Xunit;

namespace Common.Tests.Models
{
    public class SyncfusionExtensionTests
    {
        [Fact]
        public void LabelFormatTest()
        {
            // Arrange
            var date = new DateTime(2016, 2, 3, 4, 5, 6);

            // Assert
            Assert.Null(RangeIntervalType.Auto.ToFormat());
            Assert.Equal("yyyy", RangeIntervalType.Years.ToFormat());
            Assert.Equal("2016", date.ToString(RangeIntervalType.Years.ToFormat()));
        }
    }
}