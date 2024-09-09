using Common.Application;
using Common.Backend;
using System;
using Xunit;

namespace Common.Tests.Services
{
    public class TokenServiceTest
    {
        [Fact]
        public void GenerateTokenTest()
        {
            // Act
            var token = new TokenService(TokenHelper.Settings).GenerateToken("Username", "Tom Sawyer", UserType.User, "District").Token;

            // Assert
            Assert.NotNull(token);
        }

        [Fact]
        public void GenerateTokenWithoutDistrictTest()
        {
            // Act
            var token = new TokenService(TokenHelper.Settings).GenerateToken("Username", "Tom Sawyer", UserType.User).Token;

            // Assert
            Assert.NotNull(token);
        }

        [Fact]
        public void DecodeTokenWithoutDistrictTest()
        {
            // Arrange
            var token = new TokenService(TokenHelper.Settings).GenerateToken("Username", "Tom Sawyer", UserType.User, "National").Token;

            // Act
            var user = new TokenService(TokenHelper.Settings).DecodeToken(token);

            // Assert
            Assert.Equal("Username", user.Id);
            Assert.Equal("Tom Sawyer", user.Name);
            Assert.Equal(UserType.User, user.Type);
            Assert.Equal("National", user.District);
        }

        [Fact]
        public void DecodeTokenTest()
        {
            // Arrange
            var token = new TokenService(TokenHelper.Settings).GenerateToken("Username", "Tom Sawyer", UserType.User).Token;

            // Act
            var user = new TokenService(TokenHelper.Settings).DecodeToken(token);

            // Assert
            Assert.Equal("Username", user.Id);
            Assert.Equal("Tom Sawyer", user.Name);
            Assert.Equal(UserType.User, user.Type);
            Assert.Equal("National", user.District);
        }

        [Fact]
        public void InvalidTokenTest()
        {
            // Arrange
            var tokenService = new TokenService(TokenHelper.Settings);
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
            Assert.Throws<AuthorizationException>(() => tokenService.DecodeToken("invalid"));
            Assert.Equal("Invalid token.", msg);
        }
    }
}
