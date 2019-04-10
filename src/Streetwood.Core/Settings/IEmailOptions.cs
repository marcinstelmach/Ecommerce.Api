namespace Streetwood.Core.Settings
{
    public interface IEmailOptions
    {
        string Server { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string SenderAddress { get; set; }

        string SenderName { get; set; }

        int Port { get; set; }

        bool UseSSl { get; set; }
    }
}