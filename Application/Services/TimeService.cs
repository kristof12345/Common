using System;

namespace Common.Application
{
    public class TimeService : ITimeService
    {
        public DateTime Now { get { return DateTime.UtcNow; } }

        public DateTime Today { get { return Now.Date; } }

        public DateTime Tomorrow { get { return Today.AddDays(1); } }

        public DateTime Yesterday { get { return Today.AddDays(-1); } }

        public DateTime Future(TimeSpan timespan) { return Now.Add(timespan); }

        public DateTime Past(TimeSpan timespan) { return Now.Add(-timespan); }

        public TimeSpan Until(DateTime time) { return time - Now; }
    }
}
