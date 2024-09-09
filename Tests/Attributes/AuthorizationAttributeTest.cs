using Common.Application;
using Common.Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Common.Tests.Attributes
{
    public class AuthorizationAttributeTest
    {
        [Fact]
        public void ValidAuthorizationTest()
        {
            // Arrange
            var token = new TokenService(TokenHelper.Settings).GenerateToken("Username", "Tom Sawyer", UserType.User, "District").Token;

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

        [Fact]
        public void EmptyAuthorizationTest()
        {
            // Arrange
            var http = new Mock<HttpContext>(); http.Setup(a => a.Request.Headers["Authorization"]).Returns<string>(null);
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