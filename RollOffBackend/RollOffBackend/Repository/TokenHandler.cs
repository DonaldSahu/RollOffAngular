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
        public Task<string> CreateTokenAsync(LoginTable loginTable)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Creating claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, loginTable.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, loginTable.LastName));
            claims.Add(new Claim(ClaimTypes.Email, loginTable.Email));
            claims.Add(new Claim(ClaimTypes.Role, loginTable.Roles));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
