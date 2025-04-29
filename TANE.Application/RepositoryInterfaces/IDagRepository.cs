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
        Task<Dag> CreateDagAsync(Dag dag, string jwtToken);
        Task<Dag> UpdateDagAsync(Dag dag, string jwtToken);
        Task<bool> DeleteDagAsync(int id, string jwtToken);
        Task<Dag> ReadDagByIdAsync(int id, string jwtToken);
        Task<List<Dag>> ReadAllDagsAsync(string jwtToken);
    }
}
