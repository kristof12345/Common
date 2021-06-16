using System.Collections.Generic;
using Common.Application;
using Common.Web;
using Xunit;

namespace Common.Tests.Models
{
    public class WebModelTests
    {
        [Fact]
        public void BorderToStringTest()
        {
            var border = new Border();
            Assert.Equal("0px 0px 0px 0px", border.ToString());

            border = new Border("1px");
            Assert.Equal("1px 1px 1px 1px", border.ToString());

            border = new Border("1px", "2px");
            Assert.Equal("2px 1px 2px 1px", border.ToString());

            border = new Border("1px", "2px", "3px", "4px");
            Assert.Equal("1px 2px 3px 4px", border.ToString());
        }

        [Fact]
        public void ChartDataTest()
        {
            var data = new List<ChartData>
            {
                new ChartData { Id = "a", Data = 5, Color = "b", Label = "c" },
                new ChartData { Id = "1", Data = 10, Color = "2", Label = "3" }
            };

            Assert.Equal("3", data.GetById("1").Label);
            Assert.Equal(5, data.GetById("a").Data);
            Assert.Equal("b", data.GetById("a").Color);
        }
    }
}
