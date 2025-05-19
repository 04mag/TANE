using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IRejseplanSkabelonRepository
    {
        Task<List<RejseplanSkabelon>> ReadAllRejseplanSkabelonerAsync(string jwtToken);
        Task<RejseplanSkabelon> ReadRejseplanSkabelonByIdAsync(int id, string jwtToken);
        Task<RejseplanSkabelon> CreateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken);
        Task<RejseplanSkabelon> UpdateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken);
        Task<bool> DeleteRejseplanSkabelonAsync(int id, string jwtToken);
    }
}
