namespace Common.Backend;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "An entity was not found with the given ID.") : base(message) { }
}
