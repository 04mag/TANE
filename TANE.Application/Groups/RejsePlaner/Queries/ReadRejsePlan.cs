using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlaner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Queries
{
    public class ReadRejsePlan : IReadRejsePlan
    {
        private readonly IRejsePlanRepository _rejsePlanRepository;

        public ReadRejsePlan(IRejsePlanRepository rejsePlanRepository)
        {
            _rejsePlanRepository = rejsePlanRepository;
        }

        public async Task<RejsePlan> ReadRejsePlanByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RejsePlan>> ReadRejsePlanerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
