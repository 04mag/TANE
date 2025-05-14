using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;

namespace TANE.Application.RepositoryInterfaces
{
    public interface ITurSkabelonRepository
    {
        Task<bool> CreateTurSkabelon(TurSkabelonCreateDto tur, string jwtToken);
        Task<bool> UpdateTurSkabelon(int id, TurSkabelonUpdateDto dto, string jwtToken);
        Task<bool> DeleteTurSkabelon(int turId, string jwtToken);
        Task<TurSkabelonReadDto> ReadTurSkabelonById(int turId, string jwtToken);
        Task<List<TurSkabelonReadDto>> ReadAllTurSkabeloner(string jwtToken);
        Task AddDagToTurSkabelonAsync(int turId, int dagId, string jwtToken);
        Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken);
        Task RemoveDagFromTurSkabelonAsync(int turId, int dagId, string jwtToken);

        Task<ObservableCollection<TurSkabelonReadDto>> ReadAllTurSkabelonePåRejseplan(int rejseplanId, string jwtToken);
    }
}
