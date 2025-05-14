using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Application.Dtos;
using TANE.Application.Dtos.TurDagRejseplan;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IRejsePlanRepository
    {
        Task<bool> CreateRejseplan(Rejseplan rejseplan, string jwtToken);
        Task<bool> UpdateRejseplan(int id, Rejseplan tur, string jwtToken);
        Task<bool> DeleteRejseplan(int rejseplanId, string jwtToken);
        Task<Rejseplan> ReadRejseplanById(int rejseplanId, string jwtToken);
        Task<List<Rejseplan>> ReadAllRejseplaner(string jwtToken);
        Task AddTurToRejseplanAsync(Tur tur, string jwtToken);
        Task ReorderTureAsync(int rejseplanId, Tur tur, string jwtToken);
        Task RemoveTurFromRejseplanAsync(int rejseplanId, int turId, string jwtToken);
    }
}
