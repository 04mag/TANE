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
        Task<Tur> CreateTur(Tur tur);
        Task<Tur> UpdateTur(Tur tur);
        Task<bool> DeleteTur(int id);
        Task<Tur> ReadTurById(int id);
        Task<List<Tur>> ReadAllTure();
    }
}
