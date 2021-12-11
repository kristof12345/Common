using System.ComponentModel.DataAnnotations;

namespace Common.Application
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}