using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlanSkabeloner.Queries.Interfaces
{
    internal interface IReadRejsePlanSkabelon
    {
        Task<RejsePlanSkabelon> ReadRejsePlanSkabelonByIdAsync(int id);
        Task<List<RejsePlanSkabelon>> ReadRejsePlanSkabelonerAsync();
    }
}
