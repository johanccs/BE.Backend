using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Dtos;
using BE.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BE.Services
{
    public class LoginService : ILoginService
    {
        #region Readonly Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor

        public LoginService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        public async Task<User> Login(User user)
        {
            try
            {
                var loggedUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

                return loggedUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
