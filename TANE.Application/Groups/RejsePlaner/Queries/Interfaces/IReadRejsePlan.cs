using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Queries.Interfaces
{
    public interface IReadRejsePlan
    {
        Task<RejseplanReadDto> ReadRejsePlanByIdAsync(int id, string jwtToken);
        Task<List<RejseplanReadDto>> ReadRejsePlanerAsync(string jwtToken);
    }
}
