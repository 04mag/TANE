using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class RejseplanSkabelonRepository : IRejseplanSkabelonRepository
    {
        public Task<bool> CreateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRejseplanSkabelonAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<RejseplanSkabelon>> ReadAllRejseplanSkabelonerAsync(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<RejseplanSkabelon> ReadRejseplanSkabelonByIdAsync(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
