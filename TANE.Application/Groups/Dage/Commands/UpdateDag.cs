using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Dage.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Dage.Commands
{
    public class UpdateDag : IUpdateDag
    {
        private readonly IDagRepository _dagRepository;

        public UpdateDag(IDagRepository dagRepository)
        {
            _dagRepository = dagRepository;
        }

        public async Task<Dag> UpdateDagAsync(Dag dag, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
