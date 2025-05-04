using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Application.Dtos;

namespace TANE.Application.Groups.Dage.Queries.Interfaces
{
    public interface IReadDag
    {
        Task<DagReadDto> ReadDagAsync(int id, string jwtToken);
        Task<List<DagReadDto>> ReadDageAsync(string jwtToken);
    }
}
