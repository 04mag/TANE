using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IRejsePlanSkabelonRepository
    {
        Task<List<RejsePlanSkabelon>> ReadAllRejsePlanSkabelonerAsync();
        Task<RejsePlanSkabelon> ReadRejsePlanSkabelonByIdAsync(int id);
        Task CreateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon);
        Task UpdateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon);
        Task DeleteRejsePlanSkabelonAsync(int id);
    }
}
