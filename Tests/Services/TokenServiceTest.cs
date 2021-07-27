using System;
using Common.Application;
using Common.Backend;
using Xunit;

namespace Common.Tests.Services
{
    public class TokenServiceTest
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

        [Fact]
        public void DecodeTokenTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };

            // Act
            var token = new TokenService().GenerateToken("Username", new Name("Tom", "Sawyer"), UserType.User, "District").Token;
            var user = new TokenService().DecodeToken(token);

            // Assert
            Assert.Equal("Username", user.Id);
            Assert.Equal("Tom", user.Name.Firstname);
            Assert.Equal("Sawyer", user.Name.Surname);
            Assert.Equal(UserType.User, user.Type);
            Assert.Equal("District", user.District);
        }

        [Fact]
        public void DecodeTokenWithoutDistrictTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };

            // Act
            var token = new TokenService().GenerateToken("Username", new Name("Tom", "Sawyer"), UserType.User).Token;
            var user = new TokenService().DecodeToken(token);

            // Assert
            Assert.Equal("Username", user.Id);
            Assert.Equal("Tom", user.Name.Firstname);
            Assert.Equal("Sawyer", user.Name.Surname);
            Assert.Equal(UserType.User, user.Type);
            Assert.Equal("National", user.District);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var tokenService = new TokenService();
            string msg = "";

            // Act
            try
            {
                tokenService.DecodeToken("invalid");
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

            // Assert
            Assert.Throws<TokenException>(() => tokenService.DecodeToken("invalid"));
            Assert.Equal("Invalid token.", msg);
        }
    }
}
