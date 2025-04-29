using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Queries.Interfaces
{
    internal interface IReadTur
    {
        Task<Tur> ReadTurByIdAsync(int id, string jwtToken);
        Task<List<Tur>> ReadAllTureAsync(string jwtToken);
    }
}
