using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.Groups.TurSkabeloner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.TurSkabeloner.Queries
{
    public class ReadTurSkabelon : IReadTurSkabelon
    {
        private readonly ITurSkabelonRepository _turSkabelonRepository;

        public ReadTurSkabelon(ITurSkabelonRepository turSkabelonRepository)
        {
            _turSkabelonRepository = turSkabelonRepository;
        }

        public async Task<List<TurSkabelonReadDto>> ReadAllTurSkabelonerAsync(string jwtToken)
        {
            return await _turSkabelonRepository.ReadAllTurSkabeloner(jwtToken);
        }

        public async Task<TurSkabelonReadDto> ReadTurSkabelonByIdAsync(int id, string jwtToken)
        {
            return await _turSkabelonRepository.ReadTurSkabelonById(id, jwtToken);
        }
    }
}
