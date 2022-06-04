using BE.Contracts;
using BE.Data.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Services
{
    public class AuthService: IAuthService
    {
        #region Private Readonly Fields
               

        #endregion

        #region Constructor

        public AuthService()
        {
            
        }

        #endregion

        #region Methods

        public Task<ListUserDto> CreateUser(UserDto userDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListUserDto> EditUser(EditUserDto userDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ListUserDto>> LoadAllUsers()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
