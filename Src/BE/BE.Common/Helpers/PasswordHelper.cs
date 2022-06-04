using BE.Contracts;

namespace BE.Common.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        public string HashPassword(string password)
        {
            return password;
        }
    }
}
