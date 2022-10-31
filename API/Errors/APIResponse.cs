namespace API.Errors;

public class APIResponse
{
    public APIResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Your request needs to be changed.",
            401 => "Your request wasn't authorized.",
            404 => "The requested resource couldn't be found.",
            500 => "This is a server error.",
            _ => null
        };
    }
}
