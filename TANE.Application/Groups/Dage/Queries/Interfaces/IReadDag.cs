using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;
using TANE.Rejseplan.Application.Dtos;

namespace TANE.Application.Groups.Dage.Queries.Interfaces
{
    public interface IReadDag
    {
        Task<DagReadDto> ReadDagAsync(int id);
        Task<List<DagReadDto>> ReadDageAsync();
    }
}
