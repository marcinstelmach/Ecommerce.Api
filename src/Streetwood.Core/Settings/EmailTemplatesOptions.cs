namespace Streetwood.Core.Settings
{
    public class EmailTemplatesOptions
    {
        public Template NewOrder { get; set; }

        public Template ActivateNewUser { get; set; }

        public Template OrderWasShipped { get; set; }

        public Template ResetPassword { get; set; }
    }
}