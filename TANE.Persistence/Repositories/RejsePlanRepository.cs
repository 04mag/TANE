using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class RejsePlanRepository : IRejsePlanRepository
    {
        public Task<bool> CreateRejsePlan(RejsePlan rejsePlan)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRejsePlan(int rejsePlanId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RejsePlan>> ReadAllRejsePlans()
        {
            throw new NotImplementedException();
        }

        public Task<RejsePlan> ReadRejsePlanById(int rejsePlanId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRejsePlan(RejsePlan rejsePlan)
        {
            throw new NotImplementedException();
        }
    }
}
