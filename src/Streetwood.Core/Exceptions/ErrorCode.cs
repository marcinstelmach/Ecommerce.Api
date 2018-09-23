using System.Net;

namespace Streetwood.Core.Exceptions
{
    public class ErrorCode
    {
        public string ErrorCodeName { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        
        public ErrorCode(string errorCodeName, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            ErrorCodeName = errorCodeName;
            Message = message;
            StatusCode = statusCode;
        }

        public ErrorCode(string errorCodeName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : this(errorCodeName, errorCodeName, statusCode)
        {
        }
    }
}
