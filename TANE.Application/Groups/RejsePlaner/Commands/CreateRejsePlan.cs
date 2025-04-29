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
    public class CreateRejsePlan : ICreateRejsePlan
    {
        private readonly IRejsePlanRepository _rejsePlanRepository;

        public CreateRejsePlan(IRejsePlanRepository rejsePlanRepository)
        {
            _rejsePlanRepository = rejsePlanRepository;
        }

        public async Task<RejsePlan> CreateRejsePlanAsync(RejsePlan rejsePlan, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
