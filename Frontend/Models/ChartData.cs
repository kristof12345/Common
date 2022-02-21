using Common.Application;

namespace Common.Web;

public class ChartData : ILabeledValue
{
    public string Label { get; set; }

    public decimal Value { get; set; }

    public string Color { get; set; }
}
