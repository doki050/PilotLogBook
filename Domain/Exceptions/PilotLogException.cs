namespace Domain.Exceptions;

public class PilotLogException : Exception
{
    public PilotLogException(string errorCode, string message, Exception innerException = null)
    : base(message, innerException)
    {
        this.SetErrorCode(errorCode);
    }
}
