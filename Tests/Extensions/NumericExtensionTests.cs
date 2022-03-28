using Common.Application;
using Xunit;

namespace Common.Tests.Extensions
{
    public class NumericExtensionTests
    {
        [Fact]
        public void ToDoubleTest()
        {

            Assert.Equal(3.14, 3.14m.ToDouble());
            Assert.Equal(5.0, 5.0m.ToDouble());
            Assert.Equal(159.753, 159.753m.ToDouble());
        }

    }
}
