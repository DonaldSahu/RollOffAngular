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
        public async Task<LoginTable> AuthenticateUserAsync(string email, string password)
        {
            var user = await context.LoginTables.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }
    }
}
