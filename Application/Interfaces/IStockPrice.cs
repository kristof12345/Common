using System;

namespace Common.Application
{
    public interface IStockPrice : IPrice
    {
        public long Volume { get; }
    }
}