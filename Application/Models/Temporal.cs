using System;

namespace Common.Application
{
    public interface ITemporal
    {
        public DateTime Date { get; }
    }

    public interface IPrice : ITemporal
    {
        public decimal Value { get; }
    }

    public interface IStockPrice : ITemporal
    {
        public decimal Open { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public decimal Close { get; }
    }

    public interface IVolume : ITemporal
    {
        public long Volume { get; }
    }
}

