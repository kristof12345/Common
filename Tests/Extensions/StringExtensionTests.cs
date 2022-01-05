using System;
using Common.Application;
using Xunit;

namespace Common.Tests.Extensions
{
    public class StringExtensionTests
    {
        [Fact]
        public void CapitalizeFirstLetterTest()
        {
            Assert.Equal("Hello", "hello".Capitalize());
            Assert.Equal("Hello", "HELLO".Capitalize());
            Assert.Equal("Hello", "Hello".Capitalize());
            Assert.Equal("Hello world!", "hello world!".Capitalize());
            Assert.Equal("Hello world!", "HELLO WORLD!".Capitalize());
            Assert.Equal("Hello world!", "Hello World!".Capitalize());
        }
    }
}

