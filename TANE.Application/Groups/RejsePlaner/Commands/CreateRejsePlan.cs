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
    public class CreateRejseplan : ICreateRejseplan
    {
        private readonly IRejseplanRepository _rejseplanRepository;

        public CreateRejseplan(IRejseplanRepository rejseplanRepository)
        {
            _rejseplanRepository = rejseplanRepository;
        }

        public async Task<Rejseplan> CreateRejseplanAsync(Rejseplan rejseplan, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
