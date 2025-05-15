using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Application.Groups.Rejseplaner.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Rejseplaner.Queries
{
    public class ReadRejseplan : IReadRejseplan
    {
        private readonly IRejseplanRepository _rejseplanRepository;

        public ReadRejseplan(IRejseplanRepository rejseplanRepository)
        {
            _rejseplanRepository = rejseplanRepository;
        }

        public async Task<Rejseplan> ReadRejseplanByIdAsync(int id, string jwtToken)
        {
            return await _rejseplanRepository.ReadRejseplanById(id, jwtToken);
        }

        public async Task<List<Rejseplan>> ReadRejseplanerAsync(string jwtToken)
        {
            return await _rejseplanRepository.ReadAllRejseplaner(jwtToken);
        }
    }
}
