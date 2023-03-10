using Microsoft.EntityFrameworkCore;
using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public class RollOffRepository:IRollOffRepository
    {
        private readonly Roll_offContext roll_OffContext;

        //passing dbcontext class to our constructor
        public RollOffRepository(Roll_offContext roll_OffContext)
        {
            this.roll_OffContext = roll_OffContext;
        }

        public async Task<IEnumerable<MasterTable>> GetallDetailsAsync()
        {
            var employees = await roll_OffContext.MasterTables.ToListAsync();
            return employees;
        }
        public async Task<MasterTable> GetbyGGIDAsync(double ggid)
        {
            var employee = await roll_OffContext.MasterTables.FirstOrDefaultAsync(x => x.GlobalGroupId == ggid);
            return employee;
        }
        public async Task<MasterTable> GetbyEmailAsync(string value)
        {
            return await roll_OffContext.MasterTables.FirstOrDefaultAsync(x => x.Email == value);
        }
        /*public async Task<RollOffTable> GetbyNameAsync(string name)
        {
            var employee = await roll_OffContext.RollOffTables.FirstOrDefaultAsync(x => x.Name == name);
            return employee;
        }*/
    }
}
