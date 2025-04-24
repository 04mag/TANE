using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlaner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.RejsePlaner.Commands
{
    public class DeleteRejsePlan : IDeleteRejsePlan
    {
        private readonly IRejsePlanRepository _rejsePlanRepository;

        public DeleteRejsePlan(IRejsePlanRepository rejsePlanRepository)
        {
            _rejsePlanRepository = rejsePlanRepository;
        }

        public async Task<bool> DeleteRejsePlanAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
