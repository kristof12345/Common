﻿using Common.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Backend;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class AdministratorAttribute : Attribute, IAuthorizationFilter
{
    private readonly ITokenService TokenService;

    public AdministratorAttribute()
    {
        TokenService = App.Services.GetRequiredService<ITokenService>();
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            var user = TokenService.DecodeToken(token?[7..]);
            if (user.Type != UserType.Admin) throw new AuthorizationException("Admin privilages required.");
        }
        catch (Exception)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
