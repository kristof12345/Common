using System;

namespace Common.Application
{
    public interface IStockPrice : ITemporal
    {
        public decimal Open { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public decimal Close { get; }

        public long Volume { get; }
    }
}

