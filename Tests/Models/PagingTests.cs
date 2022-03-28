using System;
using System.Collections.Generic;
using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class PagingTests
    {
        [Fact]
        public void DefaultRangeToStringTest()
        {
            var range = Span.Default;
            Assert.Equal("?Start=0&Size=9", range.ToString());
        }

        [Fact]
        public void RangeToStringTest()
        {
            var range = new Span(10, 4);
            Assert.Equal("?Start=10&Size=4", range.ToString());
        }

        [Fact]
        public void DefaultDateRangeToStringTest()
        {
            var range = DateRange.Default;
            Assert.Equal("?From=0001.01.01&To=9999.12.31", range.ToString());
        }

        [Fact]
        public void NullableDateRangeToStringTest()
        {
            var range = new DateRange(null, null);
            Assert.Equal("?From=0001.01.01&To=9999.12.31", range.ToString());
        }

        [Fact]
        public void DateRangeToStringTest()
        {
            var range = new DateRange(new DateTime(2021, 12, 7), new DateTime(2021, 12, 13));
            Assert.Equal("?From=2021.12.07&To=2021.12.13", range.ToString());
        }

        [Fact]
        public void DateRangeLengthTest()
        {
            var range = new DateRange(System.DateTime.Today, System.DateTime.Today.AddDays(5));
            Assert.Equal(TimeSpan.FromDays(5), range.Length);
        }

        [Fact]
        public void EmptyPagedResultTest()
        {
            var page = new PagedResult<string>();
            Assert.Empty(page.Results);
            Assert.Equal(0, page.PageCount);
        }

        [Fact]
        public void PagedResultTest()
        {
            Span.PageSize = 4;
            var numbers = new List<int> { 1, 2, 3, 4 };
            var page = new PagedResult<int>(numbers, 30);
            Assert.Equal(4, page.Results.Count);
            Assert.Equal(8, page.PageCount);
        }

        [Fact]
        public void PagedResultTest2()
        {
            Span.PageSize = 4;
            var numbers = new List<int> { 1, 2, 3, 4 };
            var page = new PagedResult<int>(numbers, 40);
            Assert.Equal(4, page.Results.Count);
            Assert.Equal(10, page.PageCount);
        }

        [Fact]
        public void PagedResultTest3()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            var page = new PagedResult<int>(numbers, 10, 2);
            Assert.Equal(4, page.Results.Count);
            Assert.Equal(5, page.PageCount);
        }
    }
}
