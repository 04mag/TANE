// IRejseplanClient.cs
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Domain.Entities;

namespace TANE.Presentation.BlazorWebAssemply.Services
{

    public interface IRejseplanClientService
    {
        Task<IEnumerable<Rejseplan>> GetAllAsync();
        Task<Rejseplan> GetByIdAsync(int id);
        Task<Rejseplan> CreateAsync(Rejseplan dto);
        Task<Rejseplan> UpdateAsync(int id, Rejseplan dto);
        Task DeleteAsync(int id, byte[] rowVersion);

        Task AddTurToRejseplanAsync(int rejseplanId, int turId);
        Task ReorderTureAsync(int rejseplanId, TurReorderDto dto);
        Task RemoveTurFromRejseplanAsync(int rejseplanId, int turId);
    }
}