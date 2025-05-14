using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlanSkabeloner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlanSkabeloner.Queries
{
    public class ReadRejsePlanSkabelon : IReadRejsePlanSkabelon
    {
        private readonly IRejsePlanSkabelonRepository _rejsePlanSkabelonRepository;

        public ReadRejsePlanSkabelon(IRejsePlanSkabelonRepository rejsePlanSkabelonRepository)
        {
            _rejsePlanSkabelonRepository = rejsePlanSkabelonRepository;
        }

        public async Task<RejsePlanSkabelon> ReadRejsePlanSkabelonByIdAsync(int id, string jwtToken)
        {
            var result = await _rejsePlanSkabelonRepository.ReadRejsePlanSkabelonByIdAsync(id, jwtToken);

            result.TurSkabeloner = result.TurSkabeloner.OrderBy(t => t.Sekvens).ToList();

            return result;
        }

        public async Task<List<RejsePlanSkabelon>> ReadRejsePlanSkabelonerAsync(string jwtToken)
        {
            var result = await _rejsePlanSkabelonRepository.ReadAllRejsePlanSkabelonerAsync(jwtToken);

            foreach (var rejsePlanSkabelon in result)
            {
                rejsePlanSkabelon.TurSkabeloner = rejsePlanSkabelon.TurSkabeloner.OrderBy(t => t.Sekvens).ToList();
            }

            return result.OrderBy(r => r.Titel).ToList();
        }
    }
}
