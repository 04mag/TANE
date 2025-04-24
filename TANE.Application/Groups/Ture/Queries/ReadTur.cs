using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Ture.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Queries
{
    public class ReadTur : IReadTur
    {
        private readonly ITurRepository _turRepository;

        public ReadTur(ITurRepository turRepository)
        {
            _turRepository = turRepository;
        }

        public async Task<Tur> ReadTurByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tur>> ReadAllTureAsync()
        {
            throw new NotImplementedException();
        }
    }
}
