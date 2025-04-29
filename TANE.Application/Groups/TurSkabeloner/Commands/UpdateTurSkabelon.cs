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
    public class UpdateTurSkabelon : IUpdateTurSkabelon
    {
        private readonly ITurSkabelonRepository _turSkabelonRepository;
        public UpdateTurSkabelon(ITurSkabelonRepository turSkabelonRepository)
        {
            _turSkabelonRepository = turSkabelonRepository;
        }

        public async Task<TurSkabelon> UpdateTurSkabelonAsync(TurSkabelon turSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
