using Microsoft.EntityFrameworkCore;
using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly Roll_offContext context;
        public UserRepository(Roll_offContext context)
        {
            this.context = context;
        }
        public async Task<User> AuthenticateUserAsync(string email, string password,string department)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password && x.Department==department);
            return user;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User> ResetPasswordAsync(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            user.Password = password;
            //await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
