namespace Common.Application
{
    public interface IUnique : IEntity<string>
    {
        string Content { get; }
    }
}
