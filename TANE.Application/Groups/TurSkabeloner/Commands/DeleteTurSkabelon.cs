using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.TurSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.TurSkabeloner.Commands
{
    public class DeleteTurSkabelon : IDeleteTurSkabelon
    {
        private readonly ITurSkabelonRepository _turSkabelonRepository;
        public DeleteTurSkabelon(ITurSkabelonRepository turSkabelonRepository)
        {
            _turSkabelonRepository = turSkabelonRepository;
        }
        public async Task<bool> DeleteTurSkabelonAsync(int turSkabelonId, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
