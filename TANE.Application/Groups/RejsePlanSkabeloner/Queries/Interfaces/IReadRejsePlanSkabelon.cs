using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejseplanSkabeloner.Queries.Interfaces
{
    internal interface IReadRejseplanSkabelon
    {
        Task<RejseplanSkabelon> ReadRejseplanSkabelonByIdAsync(int id, string jwtToken);
        Task<List<RejseplanSkabelon>> ReadRejseplanSkabelonerAsync(string jwtToken);
    }
}
