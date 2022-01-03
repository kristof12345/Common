using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Application
{
    public class TimeRange
    {
        public static readonly TimeRange Default = new TimeRange();

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public TimeSpan Length { get { return End - Start; } }

        public TimeRange()
        {
            Start = DateTime.MinValue;
            End = DateTime.MaxValue;
        }

        public TimeRange(DateTime? from, DateTime? to)
        {
            Start = from.HasValue ? DateTime.SpecifyKind(from.Value, DateTimeKind.Utc) : DateTime.MinValue;
            End = to.HasValue ? DateTime.SpecifyKind(to.Value, DateTimeKind.Utc) : DateTime.MaxValue;
        }

        public override string ToString()
        {
            return "?From=" + Start.ToString("yyyy.MM.ddTHH:mm:ss") + "&To=" + End.ToString("yyyy.MM.ddTHH:mm:ss");
        }
    }
}
