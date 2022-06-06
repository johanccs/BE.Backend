using BE.Contracts;
using BE.Data.Entities;
using BE.Infrastructure.Notification.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BE.Tests.EmailService
{
    public class EmailServiceTests
    {
        #region Fields

        private List<CartItem> _cartItems;

        #endregion

        #region Ctor

        public EmailServiceTests()
        {
            _cartItems = new List<CartItem>()
            {
                new CartItem()
                {
                    CartId = 1,
                    Price = 100,
                    ProductId = 1,
                    Qty = 1, 
                    UserId = 1
                }
            };
        }

        #endregion


        [Fact]
        public async Task Send_Email()
        {
            INotificationService<EmailMessage> _notificationService = 
                new Infrastructure.Notification.EmailService(
                    new Config("smtpauth.mweb.co.za" , "56718804@mweb.co.za", "@1Mops4moa"));

            await _notificationService.Send(new EmailMessage {
                Body = "Test email",
                From = "johan.ccs@mweb.co.za",
                FullName = "",
                Subject = "Test email",
                To = "johan.ccs@gmail.com"
            });
        }
    }
}
