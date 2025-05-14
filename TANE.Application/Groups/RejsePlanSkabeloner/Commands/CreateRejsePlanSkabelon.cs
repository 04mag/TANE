using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejsePlanSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlanSkabeloner.Commands
{
    public class CreateRejsePlanSkabelon : ICreateRejsePlanSkabelon
    {
        private readonly IRejsePlanSkabelonRepository _rejsePlanSkabelonRepository;

        public CreateRejsePlanSkabelon(IRejsePlanSkabelonRepository rejsePlanSkabelonRepository)
        {
            _rejsePlanSkabelonRepository = rejsePlanSkabelonRepository;
        }

        public async Task<bool> CreateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon, string jwtToken)
        {
            return await _rejsePlanSkabelonRepository.CreateRejsePlanSkabelonAsync(rejsePlanSkabelon, jwtToken);
        }
    }
}
