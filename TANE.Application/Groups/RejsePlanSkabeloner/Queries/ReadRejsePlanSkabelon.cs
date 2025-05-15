using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejseplanSkabeloner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejseplanSkabeloner.Queries
{
    public class ReadRejseplanSkabelon : IReadRejseplanSkabelon
    {
        private readonly IRejseplanSkabelonRepository _rejseplanSkabelonRepository;

        public ReadRejseplanSkabelon(IRejseplanSkabelonRepository rejseplanSkabelonRepository)
        {
            _rejseplanSkabelonRepository = rejseplanSkabelonRepository;
        }

        public async Task<RejseplanSkabelon> ReadRejseplanSkabelonByIdAsync(int id, string jwtToken)
        {
            var result = await _rejseplanSkabelonRepository.ReadRejseplanSkabelonByIdAsync(id, jwtToken);

            result.TurSkabeloner = result.TurSkabeloner.OrderBy(t => t.Sekvens).ToList();

            return result;
        }

        public async Task<List<RejseplanSkabelon>> ReadRejseplanSkabelonerAsync(string jwtToken)
        {
            var result = await _rejseplanSkabelonRepository.ReadAllRejseplanSkabelonerAsync(jwtToken);

            foreach (var rejseplanSkabelon in result)
            {
                rejseplanSkabelon.TurSkabeloner = rejseplanSkabelon.TurSkabeloner.OrderBy(t => t.Sekvens).ToList();
            }

            return result.OrderBy(r => r.Titel).ToList();
        }
    }
}
