using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<string> CreateTokenAsync(User users)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Creating claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, users.Username));
            claims.Add(new Claim(ClaimTypes.Email, users.Email));
            claims.Add(new Claim(ClaimTypes.Role, users.Department));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public Task<string> GeneratePasswordTokenAsync(User users)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));

            //creating claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, users.Email));

            var credentails = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(5), signingCredentials: credentails);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
