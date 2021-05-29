namespace Common.Application.Models
{
    public interface IUnique : IEntity<string>
    {
        string Content { get; }
    }
}
