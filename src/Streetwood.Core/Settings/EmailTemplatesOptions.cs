namespace Streetwood.Core.Settings
{
    public class EmailTemplatesOptions
    {
        public string NewOrderTemplate { get; set; }

        public string NewUserTemplate { get; set; }

        public string ChangedOrderStatusTemplate { get; set; }

        public string ResetPasswordTemplate { get; set; }
    }
}