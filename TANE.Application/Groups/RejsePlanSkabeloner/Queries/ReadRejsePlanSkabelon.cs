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
            throw new NotImplementedException();
        }

        public async Task<List<RejsePlanSkabelon>> ReadRejsePlanSkabelonerAsync(string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
