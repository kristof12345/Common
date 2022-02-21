using System.ComponentModel.DataAnnotations;

namespace Common.Application;

public class ChangePasswordRequest
{
    [Required]
    public string OldPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }
}
