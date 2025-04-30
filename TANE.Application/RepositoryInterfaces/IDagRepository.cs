using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Rejseplan.Application.Dtos;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IDagRepository
    {
        Task<bool> CreateDagAsync(DagCreateDto dag, string jwtToken);
        Task<bool> UpdateDagAsync(int id, DagUpdateDto dag, string jwtToken);
        Task<bool> DeleteDagAsync(int id, string jwtToken);
        Task<DagReadDto> ReadDagByIdAsync(int id, string jwtToken);
        Task<List<DagReadDto>> ReadAllDageAsync(string jwtToken);
    }
}
