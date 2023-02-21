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
        Task<IEnumerable<MasterTable>> GetallDetailsAsync();
        Task<MasterTable> GetbyGGIDAsync(double ggid);
        Task<MasterTable> GetbyEmailAsync(string email);
        //Task<RollOffTable> GetbyNameAsync(string name);
    }
}
