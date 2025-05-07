using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Application.Groups.RejsePlaner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlaner.Queries
{
    public class ReadRejsePlan : IReadRejsePlan
    {
        private readonly IRejsePlanRepository _rejsePlanRepository;

        public ReadRejsePlan(IRejsePlanRepository rejsePlanRepository)
        {
            _rejsePlanRepository = rejsePlanRepository;
        }

        public async Task<RejseplanReadDto> ReadRejsePlanByIdAsync(int id, string jwtToken)
        {
            return await _rejsePlanRepository.ReadRejsePlanById(id, jwtToken);
        }

        public async Task<List<RejseplanReadDto>> ReadRejsePlanerAsync(string jwtToken)
        {
            return await _rejsePlanRepository.ReadAllRejsePlans(jwtToken);
        }
    }
}
