using System;
using System.Collections.Generic;
using System.Text;

namespace Streetwood.Core.Settings
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
