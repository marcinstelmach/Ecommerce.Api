namespace Streetwood.Core.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }

        public int ExpiresMinutes { get; set; }

        public string Issuer { get; set; }
    }
}
