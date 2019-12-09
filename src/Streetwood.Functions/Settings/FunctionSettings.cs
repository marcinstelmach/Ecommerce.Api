namespace Streetwood.Functions.Settings
{
    public class FunctionSettings
    {
        public string EmailServer { get; set; }

        public string EmailUsername { get; set; }

        public string EmailPassword { get; set; }

        public string EmailSenderAddress { get; set; }

        public string EmailSenderName { get; set; }

        public int EmailPort { get; set; }

        public bool EmailUseSSl { get; set; }

        public string EmailExceptionSubject { get; set; }

        public string EmailReceiverName { get; set; }

        public string EmailReceiverAddressEmail { get; set; }
    }
}