namespace Common.Application;

public interface ILabeledValue
{
    public string Label { get; }

    public decimal Value { get; }

    public string Color { get; }
}