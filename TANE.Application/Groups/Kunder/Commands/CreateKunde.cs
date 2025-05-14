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

        public async Task<Kunde> CreateKundeAsync(Kunde kunde, string jwtToken)
        {
            return await _kundeRepository.CreateKundeAsync(kunde, jwtToken);
        }

    }
}
