namespace Streetwood.Core.Settings
{
    public class EmailTemplatesOptions
    {
        public EmailTemplate NewOrder { get; set; }

        public EmailTemplate ActivateNewUser { get; set; }

        public EmailTemplate OrderWasShipped { get; set; }

        public EmailTemplate ResetPassword { get; set; }
    }
}