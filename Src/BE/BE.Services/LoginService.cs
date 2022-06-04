using BE.Contracts;
using BE.Data.Dtos;
using System.Threading.Tasks;

namespace BE.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LoggedInDto> Login(LoginDto user)
        {
            return await Task.FromResult(new LoggedInDto());
        }
    }
}
