using System;
using Common.Application;
using Newtonsoft.Json;
using JWT.Algorithms;
using JWT.Builder;

namespace Common.Backend
{
    public class TokenService : ITokenService
    {
        public AppUser GenerateToken(string username, Name name, UserType type)
        {
            return GenerateToken(username, name, type, "National");
        }

        public AppUser GenerateToken(string id, Name name, UserType type, string district)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(App.TokenSettings.Secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(App.TokenSettings.ExpireMinutes).ToUnixTimeSeconds())
                .AddClaim("id", id)
                .AddClaim("name", name)
                .AddClaim("type", type)
                .AddClaim("district", district)
                .Encode();
            return new AppUser { Id = id, Name = name, Type = type, Token = token };
        }

        public AppUser DecodeToken(string token)
        {
            try
            {
                string json = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(App.TokenSettings.Secret).MustVerifySignature().Decode(token);
                return JsonConvert.DeserializeObject<AppUser>(json);
            }
            catch (Exception)
            {
                throw new TokenException();
            }
        }
    }

    public class TokenSettings
    {
        public string Secret { get; set; }

        public int ExpireMinutes { get; set; }
    }

    public class TokenException : Exception
    {
        public TokenException(string message = "Invalid token.") : base(message) { }
    }
}