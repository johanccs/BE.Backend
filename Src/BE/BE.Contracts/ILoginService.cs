using BE.Data.Dtos;
using System.Threading.Tasks;

namespace BE.Contracts
{
    public interface ILoginService
    {
        Task<LoggedInDto> Login(LoginDto user);
    }
}
