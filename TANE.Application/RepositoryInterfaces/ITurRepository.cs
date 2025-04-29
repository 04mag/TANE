using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface ITurRepository
    {
        Task<Tur> CreateTur(Tur tur, string jwtToken);
        Task<Tur> UpdateTur(Tur tur, string jwtToken);
        Task<bool> DeleteTur(int id, string jwtToken);
        Task<Tur> ReadTurById(int id, string jwtToken);
        Task<List<Tur>> ReadAllTure(string jwtToken);
    }
}
