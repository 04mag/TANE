using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.TurSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.TurSkabeloner.Commands
{
    public class CreateTurSkabelon : ICreateTurSkabelon
    {
        private readonly ITurSkabelonRepository _turSkabelonRepository;

        public CreateTurSkabelon(ITurSkabelonRepository turSkabelonRepository)
        {
            _turSkabelonRepository = turSkabelonRepository;
        }

        public async Task<TurSkabelon> CreateTurSkabelonAsync(TurSkabelon turSkabelon, string jwtToken)
        {
            foreach (var dagTurSkabelon in turSkabelon.DagTurSkabelon)
            {
                dagTurSkabelon.Order = turSkabelon.DagTurSkabelon.IndexOf(dagTurSkabelon) + 1;
            }

            return await _turSkabelonRepository.CreateTurSkabelon(turSkabelon, jwtToken);
        }
    }
}
