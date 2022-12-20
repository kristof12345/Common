﻿namespace Common.Application;

public class IUser : IEntity<string>
{
    public virtual string Id { get; set; }

    public virtual string Firstname { get; set; }

    public virtual string Surname { get; set; }

    public virtual string Password { get; set; }

    public virtual string Email { get; set; }

    public virtual UserType Type { get; set; }

    public virtual string Image { get => $"Data/UserProfiles/{Id}.png"; }

    public virtual string Name { get => Firstname + " " + Surname; }
}