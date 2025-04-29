using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class TurRepository : ITurRepository
    {
        public Task<Tur> CreateTur(Tur tur, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTur(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tur>> ReadAllTure(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<Tur> ReadTurById(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<Tur> UpdateTur(Tur tur, string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
