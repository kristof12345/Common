namespace Common.Backend;

public class AuthorizationException : Exception
{
    public AuthorizationException(string message = "Unauthorized.") : base(message) { }
}
