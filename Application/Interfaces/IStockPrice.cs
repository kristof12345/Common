namespace Common.Application
{
    public interface IStockPrice : IPrice
    {
        public int Volume { get; }
    }
}