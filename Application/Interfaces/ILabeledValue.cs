namespace Common.Application;

public interface ILabeledValue : IUnique
{
    public decimal Value { get; }

    public string Color { get; }
}
