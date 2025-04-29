using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Ture.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.Ture.Commands
{
    public class DeleteTur : IDeleteTur
    {
        private readonly ITurRepository _turRepository;

        public DeleteTur(ITurRepository turRepository)
        {
            _turRepository = turRepository;
        }

        public async Task<bool> DeleteTurAsync(int turId, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
