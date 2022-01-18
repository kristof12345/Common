using System;

namespace Common.Backend
{
    public class MockTimeService : ITimeService
    {
        public MockTimeService(DateTime now)
        {
            Now = now;
        }

        public DateTime Now { get; set; }

        public DateTime Today { get { return Now.Date; } }

        public DateTime Tomorrow { get { return Today.AddDays(1); } }

        public DateTime Yesterday { get { return Today.AddDays(-1); } }

        public DateTime Future(TimeSpan timespan) { return Now.Add(timespan); }

        public DateTime Past(TimeSpan timespan) { return Now.Add(-timespan); }

        public TimeSpan Until(DateTime time) { return time - Now; }
    }
}