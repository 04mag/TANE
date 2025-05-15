using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Rejseplaner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Rejseplaner.Commands
{
    public class UpdateRejseplan : IUpdateRejseplan
    {
        private readonly IRejseplanRepository _rejseplanRepository;

        public UpdateRejseplan(IRejseplanRepository rejseplanRepository)
        {
            _rejseplanRepository = rejseplanRepository;
        }

        public async Task<Rejseplan> UpdateRejseplanAsync(Rejseplan rejseplan, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
