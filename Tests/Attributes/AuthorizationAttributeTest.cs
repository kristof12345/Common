using Xunit;
using Common.Backend;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Common.Application;

namespace Common.Tests.Attributes
{
    public class AuthorizationAttributeTest
    {
        [Fact]
        public void ValidAuthorizationTest()
        {
            // Arrange
            App.TokenSettings = new TokenSettings { Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==", ExpireMinutes = 3000 };
            var token = new TokenService().GenerateToken("Username", new Name("Tom", "Sawyer"), UserType.User, "District").Token;

            var http = new Mock<HttpContext>(); http.Setup(a => a.Request.Headers["Authorization"]).Returns("Bearer " + token);
            var action = new ActionContext(http.Object, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            var context = new AuthorizationFilterContext(action, new List<IFilterMetadata>());

            // Act
            new AuthorizeAttribute().OnAuthorization(context);

            var result = context.Result as JsonResult;

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void InvalidAuthorizationTest()
        {
            // Arrange
            var http = new Mock<HttpContext>(); http.Setup(a => a.Request.Headers["Authorization"]).Returns("Bearer invalid");
            var action = new ActionContext(http.Object, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            var context = new AuthorizationFilterContext(action, new List<IFilterMetadata>());

            // Act
            new AuthorizeAttribute().OnAuthorization(context);

            var result = context.Result as JsonResult;

            // Assert
            Assert.Equal(401, result.StatusCode);
            Assert.Equal("{ message = Unauthorized }", result.Value.ToString());
        }
    }
}