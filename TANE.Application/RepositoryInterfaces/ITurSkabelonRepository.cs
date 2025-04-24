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
        Task<TurSkabelon> CreateTurSkabelon(TurSkabelon tur);
        Task<TurSkabelon> UpdateTurSkabelon(TurSkabelon tur);
        Task<bool> DeleteTur(int id);
        Task<TurSkabelon> ReadTurSkabelonById(int id);
        Task<List<TurSkabelon>> ReadAllTurSkabeloner();
    }
}
