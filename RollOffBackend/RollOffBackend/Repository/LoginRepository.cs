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
        public async Task<LoginTable> AddLoginDetailsAsync(LoginTable loginTable)
        {
            await context.LoginTables.AddAsync(loginTable);
            await context.SaveChangesAsync();
            return loginTable;
        }
    }
}
