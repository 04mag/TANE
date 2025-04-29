using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface ITurSkabelonRepository
    {
        Task<TurSkabelon> CreateTurSkabelon(TurSkabelon tur, string jwtToken);
        Task<TurSkabelon> UpdateTurSkabelon(TurSkabelon tur, string jwtToken);
        Task<bool> DeleteTur(int id, string jwtToken);
        Task<TurSkabelon> ReadTurSkabelonById(int id, string jwtToken);
        Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken);
    }
}
