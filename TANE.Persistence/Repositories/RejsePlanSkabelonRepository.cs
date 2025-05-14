using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class RejsePlanSkabelonRepository : IRejsePlanSkabelonRepository
    {
        public Task<bool> CreateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRejsePlanSkabelonAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<RejsePlanSkabelon>> ReadAllRejsePlanSkabelonerAsync(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<RejsePlanSkabelon> ReadRejsePlanSkabelonByIdAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
