using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface ILoginRepository
    {
        Task<User> AddLoginDetailsAsync(User users);
    }
}
