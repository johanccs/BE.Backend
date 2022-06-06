using BE.Contracts;
using BE.Infrastructure.Notification.Classes;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BE.Infrastructure.Notification
{
    public class EmailService : INotificationService<EmailMessage>
    {
        #region Readonly Fields

        private readonly string _smtpServer;
        private readonly string _username;
        private readonly string _password;

        #endregion

        #region Ctor

        public EmailService(Config config)
        {
            _smtpServer = config.SmtpAddress;
            _username = config.Username;
            _password = config.Password;
        }

        #endregion

        #region Public Methods

        public async Task<bool> Send(EmailMessage message)
        {
            using(var smtpClient = new SmtpClient(_smtpServer))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(_username, _password);

                MailAddress from = new MailAddress(message.From);

                MailAddress to = new MailAddress(message.To);

                MailMessage msg = new MailMessage(from.Address, to.Address, message.Subject, message.Body);

                msg.SubjectEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;

                try
                {
                    smtpClient.Send(msg);
                }
                catch (Exception)
                {
                    throw;
                }

                return await Task.FromResult(true);
            }
        }

        #endregion
    }
}
