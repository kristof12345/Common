using System;

namespace Common.Application
{
    public interface IUser : IEntity<string>
    {
        public string District { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public UserType Type { get; set; }
    }
}

