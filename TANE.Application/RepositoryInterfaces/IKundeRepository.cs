using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IKundeRepository
    {
        Task<List<Kunde>> ReadAllKunderAsync(string jwtToken);
        Task<Kunde> ReadKundeByIdAsync(int id, string jwtToken);
        Task<Kunde> CreateKundeAsync(Kunde kunde, string jwtToken);
        Task<Kunde> UpdateKundeAsync(Kunde kunde, string jwtToken);
        Task<bool> DeleteKundeAsync(int id, string jwtToken);
    }
}
