using System;

namespace Common.Application
{
    public class DateRange
    {
        public static readonly DateRange Default = new DateRange();

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Length { get { return End - Start; } }

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
