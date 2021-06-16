using Xunit;
using System;
using Common.Web;

namespace Common.Tests.Attributes
{
    public class ValidationAttributeTests
    {
        [Fact]
        public void FutureDateTest()
        {
            var validator = new FutureDate();
            Assert.True(validator.IsValid(DateTime.Today.AddDays(10)));
            Assert.False(validator.IsValid(DateTime.Today.AddDays(-10)));
            Assert.True(validator.IsValid(DateTime.Now.AddSeconds(10)));
            Assert.False(validator.IsValid(DateTime.Now.AddSeconds(-10)));
        }

        [Fact]
        public void PastDateTest()
        {
            var validator = new PastDate();
            Assert.False(validator.IsValid(DateTime.Today.AddDays(10)));
            Assert.True(validator.IsValid(DateTime.Today.AddDays(-10)));
            Assert.False(validator.IsValid(DateTime.Now.AddSeconds(10)));
            Assert.True(validator.IsValid(DateTime.Now.AddSeconds(-10)));
        }

        [Fact]
        public void ZeroValueTest()
        {
            var validator = new ZeroValue();
            Assert.True(validator.IsValid(0));
            Assert.False(validator.IsValid(-10));
            Assert.False(validator.IsValid(10));
        }
    }
}
