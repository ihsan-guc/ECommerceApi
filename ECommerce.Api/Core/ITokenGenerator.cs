using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Core
{
    public interface ITokenGenerator
    {
        string Token(string userName, string email);
    }
    public class TokenGenerator : ITokenGenerator
    {
        public string Token(string userName, string email)
        {
            var token = new JwtSecurityToken(
                issuer: "Message Test",
                audience: userName,
                expires: DateTime.Now,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(email + "Test Verisidir")),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
