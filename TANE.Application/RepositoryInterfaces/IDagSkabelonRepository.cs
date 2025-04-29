using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IDagSkabelonRepository
    {
        Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dagSkabelon, string jwtToken);
        Task<DagSkabelon> UpdateDagSkabelonAsync(DagSkabelon dagSkabelon, string jwtToken);
        Task<bool> DeleteDagSkabelonAsync(int id, string jwtToken);
        Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id, string jwtToken);
        Task<List<DagSkabelon>> ReadAllDagSkabelonerAsync(string jwtToken);
    }
}
