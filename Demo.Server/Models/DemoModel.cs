using System;
using System.ComponentModel.DataAnnotations;
using Common.Application;

namespace Demo.Server
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
        public DateTime DateTime { get; set; }

        [Required]
        public DateTime? NullableDateTime { get; set; }

        [Required]
        public DateRange DateRange { get; set; } = new DateRange();

        [Required]
        public int Integer { get; set; }

        [Required]
        public int? OptionalInteger { get; set; }

        [Required]
        public double Double { get; set; }

        [Required]
        public decimal Decimal { get; set; }

        [Required]
        public string Select { get; set; }

        [Required]
        public DemoEnum Enum { get; set; }

        [Required]
        public string Color { get; set; }

        public bool Checked { get; set; }
    }

    public enum DemoEnum
    {
        First,
        Second,
        Third
    }
}
