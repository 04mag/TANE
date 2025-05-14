using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Queries.Interfaces
{
    public interface IReadKunde
    {
        Task<Kunde> GetKundeByIdAsync(int kundeId, string jwtToken);
        Task<List<Kunde>> GetAllKunderAsync(string jwtToken);
    }
}
