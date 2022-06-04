using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Dtos;
using BE.Data.Entities;
using System;
using System.Threading.Tasks;

namespace BE.Services
{
    public class AuthService: IAuthService
    {
        #region Private Readonly Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor

        public AuthService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        public async Task<User> CreateUser(User user)
        {
            try
            {
                await _dbContext.AddAsync<User>(user);

                await _dbContext.SaveChangesAsync();

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        #endregion
    }
}
