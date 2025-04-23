using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.DagSkabeloner.Queries.Interfaces
{
    internal interface IReadDagSkabelon
    {
        Task<DagSkabelon> ReadDagSkabelonByIdAsync(int id);
        Task<List<DagSkabelon>> ReadAllDagSkabelonerAsync();
    }
}
