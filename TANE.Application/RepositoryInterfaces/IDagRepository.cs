using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Application.Dtos;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IDagRepository
    {
        Task<bool> CreateDagAsync(Dag dag, string jwtToken);
        Task<bool> UpdateDagAsync(int id, Dag dag, string jwtToken);
        Task<bool> DeleteDagAsync(int id, string jwtToken);
        Task<Dag> ReadDagByIdAsync(int id, string jwtToken);
        Task<List<Dag>> ReadAllDageAsync(string jwtToken);
    }
}
