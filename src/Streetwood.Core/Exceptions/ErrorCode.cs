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

        public static ErrorCode InvalidUserCredentials => new ErrorCode(nameof(InvalidUserCredentials),
            "Invalid email or password", HttpStatusCode.UnprocessableEntity);

        public static ErrorCode InvalidUserClaimName =>
            new ErrorCode(nameof(InvalidUserClaimName), HttpStatusCode.Unauthorized);

        public static ErrorCode InvalidRefreshToken => new ErrorCode(nameof(InvalidRefreshToken));

        public static ErrorCode ProductNotFound => new ErrorCode(nameof(ProductNotFound));

        public static ErrorCode ShipmentInUse =>
            new ErrorCode(nameof(ShipmentInUse), "Cannot delete shipment, cause it is in use");

        public static ErrorCode EmailExistInDatabase =>
            new ErrorCode(nameof(EmailExistInDatabase), "Email exist in database. Use different");

        public static ErrorCode OrderDiscountInUse => new ErrorCode(nameof(OrderDiscountInUse));

        public static ErrorCode DiscountWithThisCodeExistAlready =>
            new ErrorCode(nameof(DiscountWithThisCodeExistAlready));

        public static ErrorCode OrderDiscountNotFound => new ErrorCode(nameof(OrderDiscountNotFound));

        public static ErrorCode ProductNotAcceptCharms => new ErrorCode(nameof(ProductNotAcceptCharms));

        public static ErrorCode EmailTemplateNotExists(string name) =>
            new ErrorCode($"{nameof(EmailTemplateNotExists)}_{name}");

        public static ErrorCode NoAccess => new ErrorCode(nameof(NoAccess), HttpStatusCode.Forbidden);

        public static ErrorCode EmptyImageFile => new ErrorCode(nameof(EmptyImageFile));

        public static ErrorCode InvalidId => new ErrorCode(nameof(InvalidId));

        public static ErrorCode AccessingDeactivatedUser => new ErrorCode(nameof(AccessingDeactivatedUser));

        public static ErrorCode InvalidChangePasswordToken =>
            new ErrorCode(nameof(InvalidChangePasswordToken), "Provided token is invalid.");

        public static ErrorCode CannotAddToQueue => new ErrorCode(nameof(CannotAddToQueue));

        public static ErrorCode OrderNotFound => new ErrorCode(nameof(OrderNotFound), HttpStatusCode.NotFound);

        public static ErrorCode ThisProductCategoryCanHasOnlyOneProduct => new ErrorCode(nameof(ThisProductCategoryCanHasOnlyOneProduct));

        public static ErrorCode CannotCompleteNotPendingPayment => new ErrorCode(nameof(CannotCompleteNotPendingPayment));

        public static ErrorCode CannotSendNotPendingShipment => new ErrorCode(nameof(CannotSendNotPendingShipment));

        public static ErrorCode CannotCompleteNotInProgressShipment => new ErrorCode(nameof(CannotCompleteNotInProgressShipment));

        public static ErrorCode PaymentDoesNotExists => new ErrorCode(nameof(PaymentDoesNotExists));

        public new string ToString() => $"{ErrorCodeName}: StatusCode: '{StatusCode}', Message: '{Message}'.";
    }
}