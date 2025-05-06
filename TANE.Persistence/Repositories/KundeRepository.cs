using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class KundeRepository : IKundeRepository
    {
        // Simuleret database
        private static readonly List<Kunde> _kunder = new List<Kunde>
        {
            new Kunde("Anders", "Andersen", "anders@example.com", "12345678") { Id = 1 },
            new Kunde("Birgitte", "Birk", "birgitte@example.com", "23456789") { Id = 2 },
            new Kunde("Claus", "Clausen", "claus@example.com", "34567890") { Id = 3 }
        };

        private static int _nextId = 4;

        public Task<Kunde> CreateKundeAsync(Kunde kunde, string jwtToken)
        {
            kunde.Id = _nextId++;
            _kunder.Add(kunde);
            return Task.FromResult(kunde);
        }

        public Task<bool> DeleteKundeAsync(int id, string jwtToken)
        {
            var kunde = _kunder.FirstOrDefault(k => k.Id == id);
            if (kunde == null) return Task.FromResult(false);

            _kunder.Remove(kunde);
            return Task.FromResult(true);
        }

        public Task<List<Kunde>> ReadAllKunderAsync(string jwtToken)
        {
            return Task.FromResult(_kunder.ToList());
        }

        public Task<Kunde> ReadKundeByIdAsync(int id, string jwtToken)
        {
            var kunde = _kunder.FirstOrDefault(k => k.Id == id);
            return Task.FromResult(kunde);
        }

        public Task<Kunde> UpdateKundeAsync(Kunde kunde, string jwtToken)
        {
            var eksisterende = _kunder.FirstOrDefault(k => k.Id == kunde.Id);
            if (eksisterende == null) return Task.FromResult<Kunde>(null);

            eksisterende.Fornavn = kunde.Fornavn;
            eksisterende.Efternavn = kunde.Efternavn;
            eksisterende.Email = kunde.Email;
            eksisterende.TlfNummer = kunde.TlfNummer;

            return Task.FromResult(eksisterende);
        }
    }
}
