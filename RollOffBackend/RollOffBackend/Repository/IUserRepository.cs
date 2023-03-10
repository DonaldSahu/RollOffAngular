using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface IUserRepository
    {
        Task<User> AuthenticateUserAsync(string email, string password,string department);
        Task<User> FindByEmailAsync(string email);

        Task<User> ResetPasswordAsync(string email, string password);
    }
}
