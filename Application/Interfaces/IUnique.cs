namespace Common.Application
{
    public interface IUnique : IEntity<int>
    {
        string Content { get; }
    }
}
