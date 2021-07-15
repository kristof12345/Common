using System;
using System.ComponentModel.DataAnnotations;

namespace Demo
{
    public class DemoModel
    {
        [Required]
        public string String { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Autocomplete { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public DateTime? DateTime { get; set; } 

        [Required]
        public int Integer { get; set; }

        [Required]
        public string Color { get; set; }

        public bool Checked { get; set; }

    }
}
