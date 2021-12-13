using System;
using System.Collections.Generic;
using Common.Application;

namespace Demo.Client
{
    public class DemoStock
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Currency { get; set; }

        public string Country { get; set; }

        public string Sector { get; set; }

        public string Industry { get; set; }

        public long MarketCapitalization { get; set; }

        public long NumberOfShares { get; set; }

        public string Description { get; set; }

        public decimal EPS { get; set; }

        public long EBITDA { get; set; }

        public decimal PayoutRatio { get; set; }

        public decimal ReturnOnEquity { get; set; }

        public decimal Dividend { get; set; }

        public decimal ForwardDividend { get; set; }

        public decimal Beta { get; set; }

        public decimal FairValue { get; set; }

        public decimal ExpectedReturn { get; set; }

        public List<StockPrice> Prices { get; set; }
    }

    public class StockPrice : IStockPrice
    {
        public DateTime Date { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public long Volume { get; set; }
    }
}