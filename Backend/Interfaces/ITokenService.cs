using Common.Application;

namespace Common.Backend
{
    public interface ITokenService
    {
        public AppUser GenerateToken(string username, Name name, UserType type);

        public AppUser GenerateToken(string username, Name name, UserType type, string district);

        public AppUser DecodeToken(string token);
    }
}