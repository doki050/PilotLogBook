namespace Domain.Exceptions;

public static class Extensions
{
    private const string _errorCode = "ErrorCode";
    private const string _unknownErrorCode = "medusa.unknown";

    public static string GetErrorCode(this Exception exception)
    {
        string errorCode =
            exception.Data[_errorCode]?.ToString()
            ??
            _unknownErrorCode;

        return errorCode;
    }

    public static Exception SetErrorCode(this Exception exception, string errorCode)
    {
        exception.Data[_errorCode] = errorCode;
        return exception;
    }

    public static Exception SetData(this Exception exception, string key, object data)
    {
        if (string.IsNullOrEmpty(key))
            return exception;

        exception.Data[key] = data;

        return exception;
    }

    public static Dictionary<string, object> GetData(this Exception exception)
    {
        Dictionary<string, object> exceptionData = [];

        foreach (var key in exception.Data.Keys)
        {
            if (key.ToString() == _errorCode)
                continue;

            exceptionData.Add(key.ToString(), exception.Data[key]);
        }

        return exceptionData;
    }
}
