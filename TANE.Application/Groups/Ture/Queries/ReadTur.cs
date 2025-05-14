using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Application.Groups.Ture.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Queries
{
    public class ReadTur : IReadTur
    {
        private readonly ITurRepository _turRepository;

        public ReadTur(ITurRepository turRepository)
        {
            _turRepository = turRepository;
        }

        public async Task<TurReadDto> ReadTurByIdAsync(int id, string jwtToken)
        {
           return await _turRepository.ReadTurById(id, jwtToken);
        }

        public async Task<List<TurReadDto>> ReadAllTureAsync(string jwtToken)
        {
            return await _turRepository.ReadAllTure(jwtToken);
        }
    }
}
