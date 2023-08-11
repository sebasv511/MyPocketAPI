﻿using Microsoft.IdentityModel.Tokens;
using MyPocketAPI.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyPocketAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        public AccountService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.UserId.ToString()),                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpirationMinutes"])),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
            //return string.Empty;
        }

    }
}
