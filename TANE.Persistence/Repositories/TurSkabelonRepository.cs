using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class TurSkabelonRepository : ITurSkabelonRepository
    {
        public Task<TurSkabelon> CreateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTur(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<TurSkabelon> ReadTurSkabelonById(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<TurSkabelon> UpdateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
