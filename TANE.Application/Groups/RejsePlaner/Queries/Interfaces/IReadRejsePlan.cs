using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Queries.Interfaces
{
    internal interface IReadRejsePlan
    {
        Task<RejsePlan> ReadRejsePlanByIdAsync(int id, string jwtToken);
        Task<List<RejsePlan>> ReadRejsePlanerAsync(string jwtToken);
    }
}
