namespace Common.Application.Models
{
    public class AppUser
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public Name Name { get; set; }

        public string Token { get; set; }

        public UserType Type { get; set; }
    }

    public enum UserType
    {
        User,
        Admin,
    }
}