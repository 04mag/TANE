using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.DagSkabeloner.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.DagSkabeloner.Commands
{
    public class CreateDagSkabelon : ICreateDagSkabelon
    {
        private readonly IDagSkabelonRepository _dagSkabelonRepository;

        public CreateDagSkabelon(IDagSkabelonRepository dagSkabelonRepository)
        {
            _dagSkabelonRepository = dagSkabelonRepository;
        }

        public async Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dagSkabelon)
        {
            throw new NotImplementedException();
        }
    }
}
