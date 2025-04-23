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
        Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dagSkabelon);
        Task<DagSkabelon> UpdateDagSkabelonAsync(DagSkabelon dagSkabelon);
        Task<bool> DeleteDagSkabelonAsync(int id);
        Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id);
        Task<List<DagSkabelon>> ReadAllDagSkabelonerAsync();
    }
}
