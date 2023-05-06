namespace Common.Application;

public interface IUser : IEntity<string>
{
    string Email { get; set; }

    string Firstname { get; set; }

    string Surname { get; set; }

    UserType Type { get; set; }

    string Name { get => Firstname + " " + Surname; }
}