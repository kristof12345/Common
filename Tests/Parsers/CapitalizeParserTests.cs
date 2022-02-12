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
    public class CapitalizeParserTests
    {
        [Fact]
        public void CapitalizeFirstLetterTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"hello world!\""));
            reader.Read();

            // Act
            var result = new CapitalizeParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal("Hello world!", result);
        }

        [Fact]
        public void LowerOtherCharactersTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"heLLo WorLd!\""));
            reader.Read();

            // Act
            var result = new CapitalizeParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal("Hello world!", result);
        }

        [Fact]
        public void SpecialCharactersTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"hello world!@&|űáéúőóüö\""));
            reader.Read();

            // Act
            var result = new CapitalizeParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal("Hello world!@&|űáéúőóüö", result);
        }
    }
}