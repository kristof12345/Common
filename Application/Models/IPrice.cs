using System;

namespace Common.Application
{
    public interface IPrice : ITemporal
    {
        public decimal Value { get; }
    }
}

