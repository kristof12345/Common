using Common.Application;
using Xunit;

namespace Common.Tests.Models
{
    public class FormatExtensionTests
    {
        private const decimal zero = 0.00m;
        private const decimal pi = 3.14159265359m;
        private const decimal million = 1000000m;

        private const long nulla = 0;
        private const long large = 314159265359;
        private const long billion = 1000000000;

        [Fact]
        public void FormatDecimalTest()
        {
            Assert.Equal("0,00", zero.FormatDecimal());
            Assert.Equal("3,14", pi.FormatDecimal());
            Assert.Equal("1000000,00", million.FormatDecimal());
        }

        [Fact]
        public void FormatIntegerTest()
        {
            Assert.Equal("0", zero.FormatInteger());
            Assert.Equal("3", pi.FormatInteger());
            Assert.Equal("1000000", million.FormatInteger());
        }

        [Fact]
        public void FormatPercentTest()
        {
            Assert.Equal("0,00 %", zero.FormatPercent());
            Assert.Equal("314,16 %", pi.FormatPercent());
            Assert.Equal("100000000,00 %", million.FormatPercent());
        }

        [Fact]
        public void FormatCurrencyTest()
        {
            Assert.Equal(" 0,00", zero.FormatCurrency(null));
            Assert.Equal("$ 0,00", zero.FormatCurrency("USD"));
            Assert.Equal("€ 3,14", pi.FormatCurrency("EUR"));
            Assert.Equal("£ 1 000 000,00", million.FormatCurrency("GBP"));
        }

        [Fact]
        public void FormatCurrencyIntegerTest()
        {
            Assert.Equal("$ 0", nulla.FormatCurrency("USD"));
            Assert.Equal("€ 314 159 265 359", large.FormatCurrency("EUR"));
            Assert.Equal("£ 1 000 000 000", billion.FormatCurrency("GBP"));
        }

        [Fact]
        public void FormatCurrencySpecialTest()
        {
            Assert.Equal("Unknown", zero.FormatCurrency("USD", true));
            Assert.Equal("€ 3,14", pi.FormatCurrency("EUR", true));
            Assert.Equal("Infinity", decimal.MaxValue.FormatCurrency("GBP", true));
        }

        [Fact]
        public void FormatCurrencyIntegerSpecialTest()
        {
            Assert.Equal("Unknown", nulla.FormatCurrency("USD", true));
            Assert.Equal("€ 314 159 265 359", large.FormatCurrency("EUR", true));
            Assert.Equal("Infinity", long.MaxValue.FormatCurrency("GBP", true));
        }
    }
}