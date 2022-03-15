using Common.Application;

namespace Common.Web;

public interface IChartData : ILabeledValue
{
    public string Color { get; }

    public bool Visible { get; }
}