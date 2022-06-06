namespace BE.Infrastructure.Notification.Classes
{
    public class Config
    {
        public string SmtpAddress { get; private set; }
        
        public string Username { get; private set; }
        
        public string Password { get; private set; }

        public Config(string smtpAddress, string username, string password)
        {
            SmtpAddress = smtpAddress;
            Username = username;
            Password = password;
        }
    }
}
