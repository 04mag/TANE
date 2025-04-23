using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IRejsePlanRepository
    {
        Task<bool> CreateRejsePlan(RejsePlan rejsePlan);
        Task<bool> UpdateRejsePlan(RejsePlan rejsePlan);
        Task<bool> DeleteRejsePlan(int rejsePlanId);
        Task<RejsePlan> ReadRejsePlanById(int rejsePlanId);
        Task<List<RejsePlan>> ReadAllRejsePlans();
    }
}
