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
            if (kunde == null)
                throw new ArgumentNullException(nameof(kunde));
            if (string.IsNullOrWhiteSpace(kunde.Email) || !kunde.Email.Contains("@"))
                throw new ArgumentException("Email er ikke valid", nameof(kunde.Email));
            if (kunde.TlfNummer.Length > 20)
                throw new ArgumentException("Telefonnummer må ikke være længere end 20 tegn", nameof(kunde.TlfNummer));
            if (kunde.Fornavn.Length > 50)
                throw new ArgumentException("Fornavn må ikke være længere end 50 tegn", nameof(kunde.Fornavn));
            if (kunde.Efternavn.Length > 50)
                throw new ArgumentException("Efternavn må ikke være længere end 50 tegn", nameof(kunde.Efternavn));

            return await _kundeRepository.CreateKundeAsync(kunde, jwtToken);
        }

    }
}
