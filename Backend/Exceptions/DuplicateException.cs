namespace Common.Backend;

public class DuplicateException : Exception
{
    public DuplicateException(string message = "An entity already exists with the given ID.") : base(message) { }
}