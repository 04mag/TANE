using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.Groups.TurSkabeloner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.TurSkabeloner.Queries
{
    public class ReadTurSkabelon : IReadTurSkabelon
    {
        private readonly ITurSkabelonRepository _turSkabelonRepository;

        public ReadTurSkabelon(ITurSkabelonRepository turSkabelonRepository)
        {
            _turSkabelonRepository = turSkabelonRepository;
        }

        public async Task<List<TurSkabelon>> ReadAllTurSkabelonerAsync(string jwtToken)
        {
            var result = await _turSkabelonRepository.ReadAllTurSkabeloner(jwtToken);

            foreach (var turSkabelon in result)
            {
                turSkabelon.DagTurSkabelon = turSkabelon.DagTurSkabelon.OrderBy(x => x.Order).ToList();
            }

            return result;
        }

        public async Task<TurSkabelon> ReadTurSkabelonByIdAsync(int id, string jwtToken)
        {
            var result = await _turSkabelonRepository.ReadTurSkabelonById(id, jwtToken);

            result.DagTurSkabelon = result.DagTurSkabelon.OrderBy(x => x.Order).ToList();

            return result;
        }
    }
}
