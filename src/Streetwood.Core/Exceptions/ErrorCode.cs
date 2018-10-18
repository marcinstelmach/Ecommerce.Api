using System;
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

        public static ErrorCode GenericNotExist(Type type) => new ErrorCode($"{nameof(type)}NotExist");

        public static ErrorCode CannotSaveDatabase => new ErrorCode(nameof(CannotSaveDatabase), HttpStatusCode.InternalServerError);

        public static ErrorCode DiscountDateToIsLowerThanFrom => new ErrorCode(nameof(DiscountDateToIsLowerThanFrom));

        public static ErrorCode InvalidUserCredentials => new ErrorCode(nameof(InvalidUserCredentials), HttpStatusCode.UnprocessableEntity);

        public static ErrorCode InvalidUserClaimName => new ErrorCode(nameof(InvalidUserClaimName), HttpStatusCode.Unauthorized);

        public static ErrorCode InvalidRefreshToken => new ErrorCode(nameof(InvalidRefreshToken));

        public static ErrorCode ProductNotFound => new ErrorCode(nameof(ProductNotFound));

        public static ErrorCode UnableToSavePhoto => new ErrorCode(nameof(UnableToSavePhoto), HttpStatusCode.InternalServerError);
    }
}
