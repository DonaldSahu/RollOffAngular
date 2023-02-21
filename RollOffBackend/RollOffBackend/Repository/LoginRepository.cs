using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly Roll_offContext context;

        public LoginRepository(Roll_offContext context)
        {
            this.context = context;
        }
        public async Task<User> AddLoginDetailsAsync(User users)
        {
            await context.Users.AddAsync(users);
            await context.SaveChangesAsync();
            return users;
        }
    }
}
