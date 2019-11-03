namespace Streetwood.Core.Settings
{
    public class CloudOptions
    {
        public string StorageConnectionString { get; set; }

        public string ExceptionQueue { get; set; }

        public string ExceptionFunctionUrl { get; set; }

        public string EmailTemplatesContainerName { get; set; }
    }
}
