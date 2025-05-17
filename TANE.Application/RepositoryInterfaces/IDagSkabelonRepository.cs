
using TANE.Application.Dtos.Skabeloner;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IDagSkabelonRepository
    {
        Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dag, string jwtToken);
        Task<DagSkabelon> UpdateDagSkabelonAsync(int id, DagSkabelon dag, string jwtToken);
        Task<bool> DeleteDagSkabelonAsync(int id, string jwtToken);
        Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id, string jwtToken);
        Task<List<DagSkabelon>> ReadAllDagSkabeloneAsync(string jwtToken);
    }
}
