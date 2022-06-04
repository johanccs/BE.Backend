using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE.Common.Config
{
    public static class GlobalConfig
    {
        public const string VALIDISSUER = "https://localhost:5001";

        public const string VALIDAUDIENCE = "https://localhost:5001";

        public const string SECRETKEY = "b14138d5-ec19-487b-a";

        public static string GenerateJWTToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRETKEY));
            var signingCredentialsKey = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                VALIDISSUER,
                VALIDAUDIENCE,
                new List<Claim>(),
                null,
                DateTime.Now.AddMinutes(5),
                signingCredentialsKey);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

    }
}
