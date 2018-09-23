using System;

namespace Streetwood.Core.Exceptions
{
    public class StreetwoodException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public StreetwoodException(ErrorCode errorCode)
            : this(errorCode, string.Empty)
        {
        }

        public StreetwoodException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {
        }

        public StreetwoodException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
