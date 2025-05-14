using TANE.Application.Groups.Kunder.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.Kunder.Commands
{
    public class DeleteKunde : IDeleteKunde
    {
        private readonly IKundeRepository _kundeRepository;

        public DeleteKunde(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public async Task<bool> DeleteKundeAsync(int kundeId, string jwtToken)
        {
            var resultat = await _kundeRepository.DeleteKundeAsync(kundeId, jwtToken);
            if (resultat)
            {
                return true;
            }
            else
            {
                throw new Exception("der skete en fejl ved sletning af kunden");
            }

        }
    }
}
