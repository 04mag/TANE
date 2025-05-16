using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface ITurSkabelonRepository
    {
        Task<TurSkabelon> CreateTurSkabelon(TurSkabelon tur, string jwtToken);
        Task<TurSkabelon> UpdateTurSkabelon(int id, TurSkabelon dto, string jwtToken);
        Task<bool> DeleteTurSkabelon(int turId, string jwtToken);
        Task<TurSkabelon> ReadTurSkabelonById(int turId, string jwtToken);
        Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken);

        //Ved ikke om resten bruges?
        Task AddDagToTurSkabelonAsync(int turId, int dagId, string jwtToken);
        Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken);
        Task RemoveDagFromTurSkabelonAsync(int turId, int dagId, string jwtToken);

        Task<ObservableCollection<TurSkabelon>> ReadAllTurSkabelonePåRejseplan(int rejseplanId, string jwtToken);
    }
}
