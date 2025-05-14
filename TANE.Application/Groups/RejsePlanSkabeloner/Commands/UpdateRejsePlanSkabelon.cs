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
    public class UpdateRejsePlanSkabelon : IUpdateRejsePlanSkabelon
    {
        private readonly IRejsePlanSkabelonRepository _rejsePlanSkabelonRepository;

        public UpdateRejsePlanSkabelon(IRejsePlanSkabelonRepository rejsePlanSkabelonRepository)
        {
            _rejsePlanSkabelonRepository = rejsePlanSkabelonRepository;
        }

        public async Task<bool> UpdateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon, string jwtToken)
        {
            foreach (var turSkabelon in rejsePlanSkabelon.TurSkabeloner)
            {
                turSkabelon.Sekvens = rejsePlanSkabelon.TurSkabeloner.IndexOf(turSkabelon) + 1;
            }

            var result = await _rejsePlanSkabelonRepository.UpdateRejsePlanSkabelonAsync(rejsePlanSkabelon, jwtToken);

            return result;
        }
    }
}
