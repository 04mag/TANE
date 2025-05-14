using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos.Skabeloner;

namespace TANE.Application.Groups.TurSkabeloner.Queries.Interfaces
{
    public interface IReadTurSkabelon
    {
        Task<TurSkabelonReadDto> ReadTurSkabelonByIdAsync(int id, string jwtToken);
        Task<List<TurSkabelonReadDto>> ReadAllTurSkabelonerAsync(string jwtToken);
    }
}
