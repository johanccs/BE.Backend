namespace BE.Infrastructure.Notification.Classes
{
    public class EmailMessage
    {
        public string To { get; set; }

        public string From { get; set; }

        public string FullName { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }
    }
}
