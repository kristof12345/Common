using Common.Backend;
using System;
using System.Text.Json;
using Xunit;

namespace Common.Tests.Extensions
{
    public class SerializerExtensionTests
    {
        [Fact]
        public void ReadDateTimeTest()
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

        [Fact]
        public void WriteDateTimeTest()
        {
            // Arrange
            var price = new StockPrice { Date = new DateTime(2019, 8, 1), Volume = 10 };

            // Act
            var json = JsonSerializer.Serialize(price, SerializerExtensions.CustomSerializerOptions);

            // Assert
            Assert.Equal(@"{""Date"":""2019.08.01"",""Open"":0,""High"":0,""Low"":0,""Close"":0,""Volume"":10}", json);
        }
    }
}