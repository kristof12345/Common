using System.ComponentModel.DataAnnotations;

namespace Common.Application.Models
{
    public class Name
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        public Name() { }

        public Name(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;
        }

        public override string ToString()
        {
            return Firstname + " " + Surname;
        }
    }
}
