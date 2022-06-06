using BE.Contracts;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BE.Common.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        public string HashPassword(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes("super-secret-password"));

                var hash = BitConverter.ToString(hashedPassword).Replace("-", " ").ToLower();

                return hash;
            }
        }
    }
}
