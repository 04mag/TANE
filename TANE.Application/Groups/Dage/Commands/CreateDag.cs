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
    public class CreateDag : ICreateDag
    {
        private readonly IDagRepository _dagRepository;

        public CreateDag(IDagRepository dagRepository)
        {
            _dagRepository = dagRepository;
        }

        public async Task<Dag> CreateDagAsync(Dag dag)
        {
            throw new NotImplementedException();
        }
    }
}
