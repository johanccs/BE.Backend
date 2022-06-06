using BE.Common.Helpers;
using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Entities;
using BE.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace BE.Tests.Services
{

    public class AuthServiceTests
    {
        ApplicationDbContext _dbContext;
        IPasswordHelper _passwordHelper;
        
        public AuthServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("MockBETS")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _passwordHelper = new PasswordHelper();
        }

        [Fact]
        public async Task Should_Add_New_User_NotNull()
        {
            var user = new User();
            user.Email = "johan.ccs@gmail.com";
            user.HashedPassword =  _passwordHelper.HashPassword("pass123");
            user.Name = "Johan";
            user.Surname = "Potgieter";
            user.Role = "Admin";

            AuthService _authService = new AuthService(_dbContext);
            var newUser = await _authService.CreateUser(user);

            var createdUser = await _authService.GetUser("johan.ccs@gmail.com");
            Assert.True(createdUser != null);
        }
    }
}
