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
        Task<List<RejsePlanSkabelon>> ReadAllRejsePlanSkabelonerAsync(string jwtToken);
        Task<RejsePlanSkabelon> ReadRejsePlanSkabelonByIdAsync(int id, string jwtToken);
        Task<bool> CreateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon, string jwtToken);
        Task<bool> UpdateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon, string jwtToken);
        Task<bool> DeleteRejsePlanSkabelonAsync(int id, string jwtToken);
    }
}
