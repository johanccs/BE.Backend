using BE.Data.Entities;
using System.Threading.Tasks;

namespace BE.Contracts
{
    public interface ILoginService
    {
        Task<User> Login(User user);
    }
}
