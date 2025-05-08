using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Application.Dtos;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IRejsePlanRepository
    {
        Task<bool> CreateRejseplan(RejseplanCreateDto rejseplan, string jwtToken);
        Task<bool> UpdateRejseplan(int id, RejseplanUpdateDto dto, string jwtToken);
        Task<bool> DeleteRejseplan(int rejseplanId, string jwtToken);
        Task<RejseplanReadDto> ReadRejseplanById(int rejseplanId, string jwtToken);
        Task<List<RejseplanReadDto>> ReadAllRejseplaner(string jwtToken);
        //Task AddTurToRejseplanAsync(int rejseplanId, int turId, string jwtToken);
        Task ReorderTureAsync(int rejseplanId, TurReorderDto dto, string jwtToken);

    }
}
