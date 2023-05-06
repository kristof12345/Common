using System.Text.Json;
using Common.Application;
using JWT.Algorithms;
using JWT.Builder;

namespace Common.Backend;

public class TokenService : ITokenService
{
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public AppUser GenerateToken(string username, string name, UserType type)
    {
        return GenerateToken(username, name, type, "National");
    }

    public AppUser GenerateToken(string username, string name, UserType type, string district)
    {
        var token = new JwtBuilder()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(App.TokenSettings.Secret)
            .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(App.TokenSettings.ExpireMinutes).ToUnixTimeSeconds())
            .AddClaim("id", username)
            .AddClaim("name", name)
            .AddClaim("type", type)
            .AddClaim("district", district)
            .Encode();

        return new AppUser { Id = username, Name = name, Type = type, Token = token, District = district };
    }

    public AppUser DecodeToken(string token)
    {
        try
        {
            string json = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(App.TokenSettings.Secret).MustVerifySignature().Decode(token);
            return JsonSerializer.Deserialize<AppUser>(json, options);
        }
        catch (Exception)
        {
            throw new AuthorizationException("Invalid token.");
        }
    }
}

public class TokenSettings
{
    public string Secret { get; set; }

    public int ExpireMinutes { get; set; }
}
