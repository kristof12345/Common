namespace Common.Application.Models
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
