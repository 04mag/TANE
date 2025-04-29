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
        Task<bool> CreateRejsePlan(RejsePlan rejsePlan, string jwtToken);
        Task<bool> UpdateRejsePlan(RejsePlan rejsePlan, string jwtToken);
        Task<bool> DeleteRejsePlan(int rejsePlanId, string jwtToken);
        Task<RejsePlan> ReadRejsePlanById(int rejsePlanId, string jwtToken);
        Task<List<RejsePlan>> ReadAllRejsePlans(string jwtToken);
    }
}
