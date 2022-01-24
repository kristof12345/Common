using System;
using System.Text.Json;
using Common.Backend;
using Xunit;

namespace Common.Tests.Extensions
{
    public class SerializerExtensionTests
    {
        [Fact]
        public void DateTimeParserTest()
        {
            // Arrange
            string jsonString = @"{""date"": ""2019.08.01""}";

            // Act
            var price = JsonSerializer.Deserialize<StockPrice>(jsonString, SerializerExtensions.CustomSerializerOptions);

            // Assert
            Assert.Equal(2019, price.Date.Year);
            Assert.Equal(8, price.Date.Month);
            Assert.Equal(1, price.Date.Day);
            Assert.Equal(0, price.Date.Hour);
            Assert.Equal(0, price.Date.Minute);
            Assert.Equal(0, price.Date.Second);
            Assert.Equal(DateTimeKind.Utc, price.Date.Kind);
        }
    }
}