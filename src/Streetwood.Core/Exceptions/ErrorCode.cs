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

        public static ErrorCode GenericNotExist<T>() => new ErrorCode($"{nameof(T)}NotExist");

        public static ErrorCode CannotSaveDatabase => new ErrorCode(nameof(CannotSaveDatabase), HttpStatusCode.InternalServerError);

        public static ErrorCode DiscountDateToIsLowerThanFrom => new ErrorCode(nameof(DiscountDateToIsLowerThanFrom));
    }
}
