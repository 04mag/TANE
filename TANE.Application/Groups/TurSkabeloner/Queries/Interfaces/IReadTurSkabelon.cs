using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.TurSkabeloner.Queries.Interfaces
{
    internal interface IReadTurSkabelon
    {
        Task<TurSkabelon> ReadTurSkabelonByIdAsync(int id, string jwtToken);
        Task<List<TurSkabelon>> ReadAllTurSkabelonerAsync(string jwtToken);
    }
}
