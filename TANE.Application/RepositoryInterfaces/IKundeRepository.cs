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
        Task<List<Kunde>> ReadAllKunderAsync();
        Task<Kunde> ReadKundeByIdAsync(int id);
        Task<Kunde> CreateKundeAsync(Kunde kunde);
        Task<Kunde> UpdateKundeAsync(Kunde kunde);
        Task<bool> DeleteKundeAsync(int id);
    }
}
