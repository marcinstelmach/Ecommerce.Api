namespace Streetwood.Core.Settings
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }

        public int ExpiresMinutes { get; set; }

        public string Issuer { get; set; }
    }
}
