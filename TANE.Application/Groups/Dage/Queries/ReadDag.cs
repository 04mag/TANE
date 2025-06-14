﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Dage.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Application.Dtos;

namespace TANE.Application.Groups.Dage.Queries
{
    public class ReadDag : IReadDag
    {
        private readonly IDagRepository _dagRepository;

        public ReadDag(IDagRepository dagRepository)
        {
            _dagRepository = dagRepository;
        }

        public async Task<Dag> ReadDagAsync(int id, string jwtToken)
        {
            
            return await _dagRepository.ReadDagByIdAsync(id, jwtToken);
        }

        public async Task<List<Dag>> ReadDageAsync(string jwtToken)
        {
            return await _dagRepository.ReadAllDageAsync(jwtToken);
        }
    }
}
