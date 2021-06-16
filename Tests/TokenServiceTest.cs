using Common.Application;
using Common.Backend;
using Xunit;

namespace Common.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GenerateTokenTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };

            // Act
            var token = new TokenService().GenerateToken("Username", new Name("Tom", "Sawyer"), UserType.User, "District").Token;

            // Assert
            Assert.NotNull(token);
        }

        [Fact]
        public void GenerateTokenWithoutDistrictTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };

            // Act
            var token = new TokenService().GenerateToken("Username", new Name("Tom", "Sawyer"), UserType.User).Token;

            // Assert
            Assert.NotNull(token);
        }
    }
}
