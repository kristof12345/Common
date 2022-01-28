namespace Common.Application
{
    public interface IUser : IEntity<string>
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserType Type { get; set; }

        public string Name { get; }
    }
}