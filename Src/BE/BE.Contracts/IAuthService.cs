using BE.Data.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Contracts
{
    public interface IAuthService
    {
        Task<IEnumerable<ListUserDto>> LoadAllUsers();

        Task<ListUserDto> CreateUser(UserDto userDto);

        Task<ListUserDto> EditUser(EditUserDto userDto);
    }
}
