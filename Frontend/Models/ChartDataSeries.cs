using Common.Application;
using System.Collections.Generic;

namespace Common.Web;

public class ChartDataSeries : IChartData
{
    public string Label { get; set; }

    public decimal Value { get; }

    public string Color { get; set; }

    public bool Visible { get; set; } = true;

    public IEnumerable<ITemporalValue> Data { get; set; }
}
