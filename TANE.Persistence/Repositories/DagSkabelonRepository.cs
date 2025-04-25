using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class DagSkabelonRepository : IDagSkabelonRepository
    {
        public Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dagSkabelon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDagSkabelonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DagSkabelon>> ReadAllDagSkabelonerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DagSkabelon> UpdateDagSkabelonAsync(DagSkabelon dagSkabelon)
        {
            throw new NotImplementedException();
        }
    }
}
