namespace Streetwood.Core.Constants
{
    public static class ConstantValues
    {
        public static string LogTemplate => "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level} - {Message:lj}{NewLine}{Exception}";

        public static string DevelopmentLogPath => "../Log/streetwood.log";

        public static string ProductionLogPath => "./Log/streetwood.log";

        public static string PriceDecimalType => "decimal(18,2)";

        public static string IdentityRoleName => "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        public static string InvalidDateRangesKey => "InvalidDateRanges";

        public static int DefaultResetPasswordTokenLength => 15;
    }
}
