using System;

namespace Common.Backend
{
    public interface ITimeService
    {
        DateTime Now { get; }

        DateTime Today { get; }

        DateTime Tomorrow { get; }

        DateTime Yesterday { get; }

        DateTime Future(TimeSpan timespan);

        DateTime Past(TimeSpan timespan);

        TimeSpan Until(DateTime time);
    }
}
