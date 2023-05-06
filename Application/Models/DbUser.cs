namespace Common.Application;

public class DbUser : IUser
{
    public virtual string Id { get; set; }

    public virtual string Email { get; set; }

    public virtual string Firstname { get; set; }

    public virtual string Surname { get; set; }

    public virtual string Password { get; set; }

    public virtual UserType Type { get; set; }

    public virtual string Name { get => Firstname + " " + Surname; }
}