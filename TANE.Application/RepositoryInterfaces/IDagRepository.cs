using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IDagRepository
    {
        Task<Dag> CreateDagAsync(Dag dag);
        Task<Dag> UpdateDagAsync(Dag dag);
        Task<bool> DeleteDagAsync(int id);
        Task<Dag> ReadDagByIdAsync(int id);
        Task<List<Dag>> ReadAllDagsAsync();
    }
}
