using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class DagRepository : IDagRepository
    {
        public Task<Dag> CreateDagAsync(Dag dag, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDagAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dag>> ReadAllDagsAsync(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<Dag> ReadDagByIdAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<Dag> UpdateDagAsync(Dag dag, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
