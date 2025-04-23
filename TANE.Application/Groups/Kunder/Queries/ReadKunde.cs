using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Kunder.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Queries
{
    public class ReadKunde : IReadKunde
    {
        private readonly IKundeRepository _kundeRepository;

        public ReadKunde(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public async Task<List<Kunde>> GetAllKunderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Kunde> GetKundeByIdAsync(int kundeId)
        {
            throw new NotImplementedException();
        }
    }
}
