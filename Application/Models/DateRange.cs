using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Application
{
    public class DateRange
    {
        public static readonly DateRange Default = new DateRange();

        [Required]
        public DateTime? Start { get; set; }

        [Required]
        public DateTime? End { get; set; }

        public TimeSpan Length { get { return End.Value - Start.Value; } }

        public DateRange()
        {
            Start = DateTime.MinValue;
            End = DateTime.MaxValue;
        }

        public DateRange(DateTime? from, DateTime? to)
        {
            Start = from ?? DateTime.MinValue;
            End = to ?? DateTime.MaxValue;
        }

        public override string ToString()
        {
            return "?From=" + Start + "&To=" + End;
        }
    }
}
