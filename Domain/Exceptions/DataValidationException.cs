namespace Domain.Exceptions;

public class DataValidationException : PilotLogException
{
    public DataValidationException(string errorCode = "Not speified errorcode", string message = "Data validation failed.")
        : base(errorCode, message)
    { }
}
