using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class KundeRepository : IKundeRepository
    {
        public Task<Kunde> CreateKundeAsync(Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteKundeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Kunde>> ReadAllKunderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Kunde> ReadKundeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Kunde> UpdateKundeAsync(Kunde kunde)
        {
            throw new NotImplementedException();
        }
    }
}
