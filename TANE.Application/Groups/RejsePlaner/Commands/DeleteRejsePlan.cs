using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Rejseplaner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.Rejseplaner.Commands
{
    public class DeleteRejseplan : IDeleteRejseplan
    {
        private readonly IRejseplanRepository _rejseplanRepository;

        public DeleteRejseplan(IRejseplanRepository rejseplanRepository)
        {
            _rejseplanRepository = rejseplanRepository;
        }

        public async Task<bool> DeleteRejseplanAsync(int Id, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
