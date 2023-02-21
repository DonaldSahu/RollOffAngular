using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface IFormRepository
    {
        Task<RolloffForm> AddFormAsync(RolloffForm form);
        Task<IEnumerable<RolloffForm>> GetDetailsAsync();
        Task<RolloffForm> GetDetailsGGID(double ggid);
        Task<RolloffForm> UpdateForm(double ggid, RolloffForm form);
        Task<RolloffForm> DeleteForm(double ggid);
    }
}
