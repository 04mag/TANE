using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.DagSkabeloner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.DagSkabeloner.Queries
{
    public class ReadDagSkabelon : IReadDagSkabelon
    {
        private readonly IDagSkabelonRepository _dagSkabelonRepository;

        public ReadDagSkabelon(IDagSkabelonRepository dagSkabelonRepository)
        {
            _dagSkabelonRepository = dagSkabelonRepository;
        }

        public async Task<List<DagSkabelon>> ReadAllDagSkabelonerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
