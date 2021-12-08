using System;

namespace Common.Application
{
    public interface ITemporalValue : ITemporal
    {
        public decimal Value { get; }
    }
}

