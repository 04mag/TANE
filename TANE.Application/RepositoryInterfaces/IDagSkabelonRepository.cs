
using TANE.Application.Dtos.Skabeloner;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IDagSkabelonRepository
    {
        Task<bool> CreateDagSkabelonAsync(DagSkabelonCreateDto dag, string jwtToken);
        Task<bool> UpdateDagSkabelonAsync(int id, DagSkabelonUpdateDto dag, string jwtToken);
        Task<bool> DeleteDagSkabelonAsync(int id, string jwtToken);
        Task<DagSkabelonReadDto> ReadDagSkabelonByIdAsync(int id, string jwtToken);
        Task<List<DagSkabelonReadDto>> ReadAllDagSkabeloneAsync(string jwtToken);
    }
}
