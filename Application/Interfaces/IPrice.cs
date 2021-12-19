using System;
namespace Common.Application
{
    public interface IPrice : ITemporal
    {
        public decimal Open { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public decimal Close { get; }
    }
}