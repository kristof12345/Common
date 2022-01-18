using System;

namespace Common.Application
{
    public static class RandomExtensions
    {
        public static double Next(this Random random, double minimum, double maximum)
        {
            return (random.NextDouble() * (maximum - minimum)) + minimum;
        }

        public static decimal Next(this Random random, decimal minimum, decimal maximum)
        {
            return (new decimal(random.NextDouble()) * (maximum - minimum)) + minimum;
        }

        public static decimal NextDecimal(this Random random)
        {
            return (new decimal(random.NextDouble()));
        }
    }
}