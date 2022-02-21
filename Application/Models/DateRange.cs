using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Application;

public class DateRange
{
    public static readonly DateRange Default = new DateRange();

    [Required]
    public DateTime Start { get; set; }

    [Required]
    public DateTime End { get; set; }

    public TimeSpan Length { get => End - Start; }

    public DateRange()
    {
        Start = DateTime.MinValue;
        End = DateTime.MaxValue;
    }

    public DateRange(DateTime? from, DateTime? to)
    {
        Start = from.HasValue ? DateTime.SpecifyKind(from.Value, DateTimeKind.Utc) : DateTime.MinValue;
        End = to.HasValue ? DateTime.SpecifyKind(to.Value, DateTimeKind.Utc) : DateTime.MaxValue;
    }

    public override string ToString()
    {
        return "?From=" + Start.ToString(Format.DateFormat) + "&To=" + End.ToString(Format.DateFormat);
    }
}
