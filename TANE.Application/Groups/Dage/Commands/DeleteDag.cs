using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Dage.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.Dage.Commands
{
    public class DeleteDag : IDeleteDag
    {
        private readonly IDagRepository _dagRepository;

        public DeleteDag(IDagRepository dagRepository)
        {
            _dagRepository = dagRepository;
        }

        public async Task<bool> DeleteDagAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
