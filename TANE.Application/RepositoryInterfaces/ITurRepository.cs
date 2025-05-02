using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Rejseplan.Application.Dtos;

namespace TANE.Application.RepositoryInterfaces
{
    public interface ITurRepository
    {
        Task<bool> CreateTur(TurCreateDto tur, string jwtToken);
        Task<bool> UpdateTur(int id, TurUpdateDto dto, string jwtToken);
        Task<bool> DeleteTur(int turId, string jwtToken);
        Task<TurReadDto> ReadTurById(int turId, string jwtToken);
        Task<List<TurReadDto>> ReadAllTure(string jwtToken);
        Task AddDagToTurAsync(int turId, int dagId, string jwtToken);
        Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken);
        Task RemoveDagFromTurAsync(int turId, int dagId, string jwtToken);

    }
}