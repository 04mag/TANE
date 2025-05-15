using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.RejseplanSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejseplanSkabeloner.Commands
{
    public class UpdateRejseplanSkabelon : IUpdateRejseplanSkabelon
    {
        private readonly IRejseplanSkabelonRepository _rejseplanSkabelonRepository;

        public UpdateRejseplanSkabelon(IRejseplanSkabelonRepository rejseplanSkabelonRepository)
        {
            _rejseplanSkabelonRepository = rejseplanSkabelonRepository;
        }

        public async Task<bool> UpdateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            foreach (var turSkabelon in rejseplanSkabelon.TurSkabeloner)
            {
                turSkabelon.Sekvens = rejseplanSkabelon.TurSkabeloner.IndexOf(turSkabelon) + 1;
            }

            var result = await _rejseplanSkabelonRepository.UpdateRejseplanSkabelonAsync(rejseplanSkabelon, jwtToken);

            return result;
        }
    }
}
