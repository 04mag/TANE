using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Application.Dtos;
using System.Collections.ObjectModel;

namespace TANE.Application.RepositoryInterfaces
{
    public interface ITurRepository
    {
        Task<bool> CreateTur(Tur tur, string jwtToken);
        Task<bool> UpdateTur(int id, Tur dto, string jwtToken);
        Task<bool> DeleteTur(int turId, string jwtToken);
        Task<Tur> ReadTurById(int turId, string jwtToken);
        Task<List<Tur>> ReadAllTure(string jwtToken);
        Task AddDagToTurAsync(int turId, int dagId, string jwtToken);
        Task ReorderDageAsync(int turId, Dag dto, string jwtToken);
        Task RemoveDagFromTurAsync(int turId, int dagId, string jwtToken);

        Task<ObservableCollection<Tur>> ReadAllTurePåRejseplan(int rejseplanId, string jwtToken);

    }
}