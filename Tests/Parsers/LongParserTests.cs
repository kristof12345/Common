using Common.Backend;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Common.Tests.Parsers
{
    public class LongParserTests
    {
        [Fact]
        public void ParseNumberTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"123456789\""));
            reader.Read();

            // Act
            var result = new LongParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(123456789, result);
        }

        [Fact]
        public void ParseNoneTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("\"None\""));
            reader.Read();

            // Act
            var result = new LongParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(0, result);
        }
    }
}