using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlaner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Commands
{
    public class UpdateRejsePlan : IUpdateRejsePlan
    {
        private readonly IRejsePlanRepository _rejsePlanRepository;

        public UpdateRejsePlan(IRejsePlanRepository rejsePlanRepository)
        {
            _rejsePlanRepository = rejsePlanRepository;
        }

        public async Task<RejsePlan> UpdateRejsePlanAsync(RejsePlan rejsePlan)
        {
            throw new NotImplementedException();
        }
    }
}
