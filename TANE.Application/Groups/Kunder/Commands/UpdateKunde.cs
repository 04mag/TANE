using TANE.Application.Groups.Kunder.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Commands
{
    public class UpdateKunde : IUpdateKunde
    {
        private readonly IKundeRepository _kundeRepository;

        public UpdateKunde(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public async Task<Kunde> UpdateKundeAsync(Kunde kunde, string jwtToken)
        {
            return await _kundeRepository.UpdateKundeAsync(kunde, jwtToken);
        }
    }
}
