using BE.Data.Entities;
using System.Threading.Tasks;

namespace BE.Contracts
{
    public interface IAuthService
    {
        Task<User>GetUser(int id);

        Task<User> CreateUser(User user);
    }
}
