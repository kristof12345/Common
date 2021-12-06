using System;
using System.Collections.Generic;
using Common.Application;

namespace Common.Web
{
    public class ChartDataSeries : IEntity<string>
    {
        public string Id { get; set; }

        public IEnumerable<IPrice> Data { get; set; }

        public string Color { get; set; }
    }
}
