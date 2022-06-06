using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Entities;
using BE.Infrastructure.Notification.Classes;
using BE.Infrastructure.Notification.Classes.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Services
{
    public class CartService : ICartService
    {
        #region Private Readonly Fields

        private readonly ApplicationDbContext _dbContext;
        private readonly INotificationService<EmailMessage> _mailService;

        #endregion

        #region Constructor

        public CartService(ApplicationDbContext dbContext, INotificationService<EmailMessage>mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        #endregion

        #region Public Methods

        public async Task<bool> CheckOut(List<CartItem> cartItems)
        {
            try
            {
                if (await SaveAsync(cartItems))
                {
                    var results = Requery(cartItems);
                    await SendNotificationAsync(results);
                }
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private async Task<bool> SendNotificationAsync(List<CartItem>cartItems)
        {
            try
            {
                _mailService.Send(new EmailMessage
                {
                    Body = BuildBody(cartItems),
                    From = "johan.ccs@mweb.co.za",
                    Subject = $"Order Nr - {cartItems[0].OrderNr}",
                    To = cartItems[0].User.Email,
                    FullName = $"{cartItems[0].User.Name} {cartItems[0].User.Surname}"
                });

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> SaveAsync(List<CartItem> cartItems)
        {
            try
            {
                await _dbContext.Cart.AddRangeAsync(cartItems);

                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                var s = ex;
                throw;
            }
        }

        private string BuildBody(List<CartItem>cartItems)
        {
            var builder = new StringBuilder();

            builder.AppendLine(TabularFormat.Display(cartItems));

            return builder.ToString();
        }

        private List<CartItem>Requery(List<CartItem>items)
        {
            var results = new List<CartItem>();

            foreach(var item in items)
            {
               var result = _dbContext.Cart
                                      .Where(x => x.UserId == item.UserId && x.CartId == item.CartId)
                                      .Include(x => x.User)
                                      .Include(y => y.Product)
                                      .FirstOrDefault();

                results.Add(result);
            }

            return results;
        }

        #endregion
    }
}
