using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface IFormRepository
    {
        Task<FormTable> AddFormAsync(FormTable form);
        Task<IEnumerable<FormTable>> GetDetailsAsync();
        Task<FormTable> GetDetailsGGID(double ggid);
        Task<FormTable> UpdateForm(double ggid, FormTable form);
        Task<FormTable> DeleteForm(double ggid);
    }
}
