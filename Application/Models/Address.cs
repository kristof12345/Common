using System.ComponentModel.DataAnnotations;

namespace Common.Application
{
    public class Address
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Number { get; set; }

        public override string ToString()
        {
            return City + ", " + Street + " " + Number;
        }
    }
}
