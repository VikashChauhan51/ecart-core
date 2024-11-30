namespace Ecart.Core.Exceptions;


public class TooManyRequestsException : Exception
{
    public TooManyRequestsException()
        : base("Too many requests have been made. Please try again later.")
    {
    }

    public TooManyRequestsException(string message)
        : base(message)
    {
    }

    public TooManyRequestsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public TooManyRequestsException(IEnumerable<string> errors)
        : base("Too many requests have been made. Please try again later.")
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; }
}

