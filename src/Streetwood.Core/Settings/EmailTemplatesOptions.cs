namespace Streetwood.Core.Settings
{
    public class EmailTemplatesOptions
    {
        public Template NewOrder { get; set; }

        public Template ActivateNewUser { get; set; }

        public Template ChangedOrderStatus { get; set; }

        public Template ResetPassword { get; set; }
    }
}