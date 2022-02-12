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
    public class TimeParserTests
    {
        [Fact]
        public void ParseTimeTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"1596584406\""));
            reader.Read();

            // Act
            var result = new TimeParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(new DateTime(2020, 8, 4, 23, 40, 6), result);
        }
    }
}