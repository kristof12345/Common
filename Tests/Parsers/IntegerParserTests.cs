using System.Text;
using System.Text.Json;
using Common.Backend;
using Xunit;

namespace Common.Tests.Parsers
{
    public class IntegerParserTests
    {
        [Fact]
        public void ParseIntegerTests()
        {
            // Arrange
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes("123"));
            reader.Read();

            // Act
            var result = new IntParser().Read(ref reader, typeof(string), null);

            // Assert
            Assert.Equal(123, result);
        }
    }
}