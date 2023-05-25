using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Backend;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly ITokenService TokenService;

    public AuthorizeAttribute()
    {
        TokenService = App.Services.GetRequiredService<ITokenService>();
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            TokenService.DecodeToken(token?[7..]);
        }
        catch (Exception)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
