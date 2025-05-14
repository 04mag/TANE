// IRejseplanClient.cs
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TANE.Application.Dtos;

namespace TANE.Presentation.BlazorWebAssemply.Services
{

    public interface IRejseplanClientService
    {
        Task<IEnumerable<RejseplanReadDto>> GetAllAsync();
        Task<RejseplanReadDto> GetByIdAsync(int id);
        Task<RejseplanReadDto> CreateAsync(RejseplanCreateDto dto);
        Task<RejseplanReadDto> UpdateAsync(int id, RejseplanUpdateDto dto);
        Task DeleteAsync(int id, byte[] rowVersion);

        Task AddTurToRejseplanAsync(int rejseplanId, int turId);
        Task ReorderTureAsync(int rejseplanId, TurReorderDto dto);
        Task RemoveTurFromRejseplanAsync(int rejseplanId, int turId);
    }
}