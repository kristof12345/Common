namespace Common.Application;

public interface IUnique : IEntity<int>
{
    public string Label { get; }
}
