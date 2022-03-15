namespace Common.Web;

public class ChartData : IChartData
{
    public string Label { get; set; }

    public decimal Value { get; set; }

    public string Color { get; set; }

    public bool Visible { get; set; } = true;
}
