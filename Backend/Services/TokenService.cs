using System.Security.Cryptography;
using System.Text.Json;
using System.Xml.Linq;
using Common.Application;
using JWT.Algorithms;
using JWT.Builder;

namespace Common.Backend;

public class TokenService : ITokenService
{
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    private readonly string Secret;

    private readonly RSA PublicKey;

    private readonly RSA PrivateKey;

    private readonly int ExpireMinutes;

    public TokenService(TokenSettings settings)
    {
        Secret = settings.Secret;
        ExpireMinutes = settings.ExpireMinutes;

        PublicKey = RSA.Create();
        PublicKey.ImportFromPem(settings.PublicKey);

        PrivateKey = RSA.Create();
        PrivateKey.ImportFromPem(settings.PrivateKey);
    }

    public AppUser GenerateToken(string username, string name, UserType type)
    {
        return GenerateToken(username, name, type, "National");
    }

    public AppUser GenerateToken(string username, string name, UserType type, string district)
    {
        var token = new JwtBuilder()
            .WithAlgorithm(new RS512Algorithm(PublicKey, PrivateKey))
            .WithSecret(Secret)
            .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(ExpireMinutes).ToUnixTimeSeconds())
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
            string json = new JwtBuilder().WithAlgorithm(new RS512Algorithm(PublicKey, PrivateKey)).WithSecret(Secret).MustVerifySignature().Decode(token);
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

    public string PublicKey { get; set; }

    public string PrivateKey { get; set; }

    public int ExpireMinutes { get; set; }
}
