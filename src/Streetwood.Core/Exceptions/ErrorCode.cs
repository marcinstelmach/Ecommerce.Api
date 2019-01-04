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

        public static ErrorCode GenericNotExist(Type type, string message = null) =>
            new ErrorCode($"{type.Name}NotExist", message);

        public static ErrorCode CannotSaveDatabase =>
            new ErrorCode(nameof(CannotSaveDatabase), HttpStatusCode.InternalServerError);

        public static ErrorCode DiscountDateToIsLowerThanFrom => new ErrorCode(nameof(DiscountDateToIsLowerThanFrom));

        public static ErrorCode InvalidUserCredentials => new ErrorCode(nameof(InvalidUserCredentials),
            "Invalid email or password", HttpStatusCode.UnprocessableEntity);

        public static ErrorCode InvalidUserClaimName =>
            new ErrorCode(nameof(InvalidUserClaimName), HttpStatusCode.Unauthorized);

        public static ErrorCode InvalidRefreshToken => new ErrorCode(nameof(InvalidRefreshToken));

        public static ErrorCode ProductNotFound => new ErrorCode(nameof(ProductNotFound));

        public static ErrorCode UnableToSavePhoto =>
            new ErrorCode(nameof(UnableToSavePhoto), HttpStatusCode.InternalServerError);

        public static ErrorCode UnableToDeletePhoto =>
            new ErrorCode(nameof(UnableToDeletePhoto), HttpStatusCode.InternalServerError);

        public static ErrorCode ShipmentInUse =>
            new ErrorCode(nameof(ShipmentInUse), "Cannot delete shipment, cause it is in use");

        public static ErrorCode EmailExistInDatabase =>
            new ErrorCode(nameof(EmailExistInDatabase), "Email exist in database. Use different");

        public static ErrorCode OrderDiscountInUse => new ErrorCode(nameof(OrderDiscountInUse));

        public static ErrorCode OrderProductsNotFound => new ErrorCode(nameof(OrderProductsNotFound));

        public static ErrorCode OrderCharmsNotFound => new ErrorCode(nameof(OrderCharmsNotFound));

        public static ErrorCode DiscountWithThisCodeExistAlready =>
            new ErrorCode(nameof(DiscountWithThisCodeExistAlready));

        public static ErrorCode NoProductsForNewOrder => new ErrorCode(nameof(NoProductsForNewOrder), HttpStatusCode.InternalServerError);

        public static ErrorCode OrderBasePriceBelowZero => new ErrorCode(nameof(OrderBasePriceBelowZero), HttpStatusCode.InternalServerError);

        public new string ToString() => $"{ErrorCodeName}: {StatusCode}, {Message}";
    }
}