using System;

namespace Common.Backend
{
    public class TimeService : ITimeService
    {
        public DateTime Now { get => DateTime.UtcNow; }

        public DateTime Today { get => Now.Date; }

        public DateTime Tomorrow { get => Today.AddDays(1); }

        public DateTime Yesterday { get => Today.AddDays(-1); }

        public DateTime Future(TimeSpan timespan) { return Now.Add(timespan); }

        public DateTime Past(TimeSpan timespan) { return Now.Add(-timespan); }

        public TimeSpan Until(DateTime time) { return time - Now; }
    }
}
