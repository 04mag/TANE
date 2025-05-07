using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Queries.Interfaces
{
    public interface IReadTur
    {
        Task<TurReadDto> ReadTurByIdAsync(int id, string jwtToken);
        Task<List<TurReadDto>> ReadAllTureAsync(string jwtToken);
    }
}
