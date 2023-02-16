using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface IRollOffRepository
    {
        //get all
        //search by ggid
        //search by email
        //search by name
        Task<IEnumerable<RollOffTable>> GetallDetailsAsync();
        Task<RollOffTable> GetbyGGIDAsync(double ggid);
        Task<RollOffTable> GetbyEmailAsync(string email);
        //Task<RollOffTable> GetbyNameAsync(string name);
    }
}
