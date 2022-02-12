using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Common.Application;
using Common.Backend;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Tests.Parsers
{
    public class DecimalParserTests
    {
        [Fact]
        public void ParseDecimalTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"123.456\""));
            reader.Read();

            // Act
            var result = new DecimalParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(123.456m, result);
        }

        [Fact]
        public void ParseIntTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"789\""));
            reader.Read();

            // Act
            var result = new DecimalParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(789, result);
        }

        [Fact]
        public void ParseNoneTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"None\""));
            reader.Read();

            // Act
            var result = new DecimalParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(0, result);
        }
    }
}