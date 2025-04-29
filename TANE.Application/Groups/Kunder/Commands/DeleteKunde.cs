using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Kunder.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.Kunder.Commands
{
    public class DeleteKunde : IDeleteKunde
    {
        private readonly IKundeRepository _kundeRepository;

        public DeleteKunde(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        public async Task<bool> DeleteKundeAsync(int kundeId, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
