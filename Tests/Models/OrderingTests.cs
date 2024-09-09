using Common.Application;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Common.Tests.Models
{
    public class OrderingTests
    {
        [Fact]
        public void AscendingOrderTest()
        {
            var order = new Ordering<string>(s => s, false);

            var list = new List<string> { "a", "c", "d", "b" }.OrderBy(order.Expression.Compile()).ToList();

            Assert.False(order.Descending);
            Assert.Equal("a", list[0]);
            Assert.Equal("b", list[1]);
            Assert.Equal("c", list[2]);
            Assert.Equal("d", list[3]);
        }

        [Fact]
        public void DescendingOrderTest()
        {
            var order = new Ordering<string>(s => s, true);

            var list = new List<string> { "a", "c", "d", "b" }.OrderByDescending(order.Expression.Compile()).ToList();

            Assert.True(order.Descending);
            Assert.Equal("d", list[0]);
            Assert.Equal("c", list[1]);
            Assert.Equal("b", list[2]);
            Assert.Equal("a", list[3]);
        }
    }
}
