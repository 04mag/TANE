using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos.Skabeloner;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.DagSkabeloner.Queries.Interfaces
{
    public interface IReadDagSkabelon
    {
        Task<DagSkabelonReadDto> ReadDagSkabelonByIdAsync(int id, string jwtToken);
        Task<List<DagSkabelonReadDto>> ReadAllDagSkabelonerAsync(string jwtToken);
    }
}
