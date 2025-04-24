using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Kunder.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Commands
{
    public class CreateKunde : ICreateKunde
    {
        private readonly IKundeRepository _kundeRepository;

        public CreateKunde(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public async Task<Kunde> CreateKundeAsync(Kunde kunde)
        {
            throw new NotImplementedException();
        }
    }
}
