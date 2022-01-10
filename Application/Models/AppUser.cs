using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Application
{
    public class AppUser
    {
        public string Id { get; set; }

        public Name Name { get; set; }

        public string District { get; set; }

        public UserType Type { get; set; }

        public string Token { get; set; }
    }

    public enum UserType
    {
        [Display(Name = "User")]
        [EnumMember(Value = "User")]
        User,
        [Display(Name = "Temporary worker")]
        [EnumMember(Value = "Temporary worker")]
        Worker,
        [Display(Name = "Permanent resident")]
        [EnumMember(Value = "Permanent resident")]
        Resident,
        [Display(Name = "Citizen")]
        [EnumMember(Value = "Citizen")]
        Citizen,
        [Display(Name = "Municipal employee")]
        [EnumMember(Value = "Municipal employee")]
        Municipal,
        [Display(Name = "Government employee")]
        [EnumMember(Value = "Government employee")]
        Government,
        [Display(Name = "Administrator")]
        [EnumMember(Value = "Administrator")]
        Admin,
        [Display(Name = "Server")]
        [EnumMember(Value = "Server")]
        Server,
    }
}