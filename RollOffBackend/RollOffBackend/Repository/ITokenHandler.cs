using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User users);
        Task<string> GeneratePasswordTokenAsync(User users);
    }
}
