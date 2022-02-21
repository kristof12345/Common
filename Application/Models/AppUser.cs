using System.Runtime.Serialization;

namespace Common.Application;

public class AppUser
{
    public string Id { get; set; }

    public Name Name { get; set; }

    public string District { get; set; }

    public UserType Type { get; set; }

    public string Token { get; set; }

    public string Image { get; set; }
}

public enum UserType
{
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Temporary worker")]
    Worker,
    [EnumMember(Value = "Permanent resident")]
    Resident,
    [EnumMember(Value = "Citizen")]
    Citizen,
    [EnumMember(Value = "Municipal employee")]
    Municipal,
    [EnumMember(Value = "Government employee")]
    Government,
    [EnumMember(Value = "Administrator")]
    Admin,
    [EnumMember(Value = "Server")]
    Server,
}
