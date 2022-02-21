namespace Common.Application;

public interface IEntity<T>
{
    public T Id { get; set; }
}
