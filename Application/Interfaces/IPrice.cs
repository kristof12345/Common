using System;

namespace Common.Application
{
    public interface IPrice : ITemporal
    {
        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }
    }
}