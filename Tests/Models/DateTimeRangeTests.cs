using System;
using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class DateTimeRangeTests
    {
        [Fact]
        public void EmptyDateRangeTest()
        {
            var range = new DateRange();

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01&To=9999.12.31", range.ToString());
        }

        [Fact]
        public void NullDateRangeTest()
        {
            var range = new DateRange(null, null);

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01&To=9999.12.31", range.ToString());
        }

        [Fact]
        public void DefaultDateRangeTest()
        {
            var range = DateRange.Default;

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01&To=9999.12.31", range.ToString());
        }

        [Fact]
        public void DateRangeTest()
        {
            var range = new DateRange(new DateTime(2020, 1, 1), new DateTime(2021, 8, 7));

            Assert.Equal(new DateTime(2020, 1, 1), range.Start);
            Assert.Equal(new DateTime(2021, 8, 7), range.End);
            Assert.Equal("?From=2020.01.01&To=2021.08.07", range.ToString());
            Assert.Equal(TimeSpan.FromDays(584), range.Length);
        }

        [Fact]
        public void EmptyTimeRangeTest()
        {
            var range = new TimeRange();

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01T00:00:00&To=9999.12.31T23:59:59", range.ToString());
        }

        [Fact]
        public void NullTimeRangeTest()
        {
            var range = new TimeRange(null, null);

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01T00:00:00&To=9999.12.31T23:59:59", range.ToString());
        }

        [Fact]
        public void DefaultTimeRangeTest()
        {
            var range = TimeRange.Default;

            Assert.Equal(DateTime.MinValue, range.Start);
            Assert.Equal(DateTime.MaxValue, range.End);
            Assert.Equal("?From=0001.01.01T00:00:00&To=9999.12.31T23:59:59", range.ToString());
        }

        [Fact]
        public void TimeRangeTest()
        {
            var range = new TimeRange(new DateTime(2020, 1, 1, 20, 20, 20), new DateTime(2021, 8, 7, 10, 11, 12));

            Assert.Equal(new DateTime(2020, 1, 1, 20, 20, 20), range.Start);
            Assert.Equal(new DateTime(2021, 8, 7, 10, 11, 12), range.End);
            Assert.Equal("?From=2020.01.01T20:20:20&To=2021.08.07T10:11:12", range.ToString());
            Assert.Equal(new TimeSpan(583, 13, 50, 52), range.Length);
        }
    }
}