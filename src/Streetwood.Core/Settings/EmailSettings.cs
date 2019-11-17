namespace Streetwood.Core.Settings
{
    public class EmailSettings
    {
        public string Server { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string SenderAddress { get; set; }

        public string SenderName { get; set; }

        public int Port { get; set; }

        public bool UseSSl { get; set; }
    }
}
