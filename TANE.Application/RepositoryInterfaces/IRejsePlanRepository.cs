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
        Task<bool> CreateRejsePlan(RejseplanCreateDto rejsePlan, string jwtToken);
        Task<bool> UpdateRejsePlan(int id, RejseplanUpdateDto dto, string jwtToken);
        Task<bool> DeleteRejsePlan(int rejsePlanId, string jwtToken);
        Task<RejseplanReadDto> ReadRejsePlanById(int rejsePlanId, string jwtToken);
        Task<List<RejseplanReadDto>> ReadAllRejsePlans(string jwtToken);
        Task AddTurToRejseplanAsync(int rejseplanId, int turId, string jwtToken);
        Task ReorderTureAsync(int rejseplanId, TurReorderDto dto, string jwtToken);

    }
}
