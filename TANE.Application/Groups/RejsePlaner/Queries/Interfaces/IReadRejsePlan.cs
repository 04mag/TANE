using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Rejseplaner.Queries.Interfaces
{
    public interface IReadRejseplan
    {
        Task<Rejseplan> ReadRejseplanByIdAsync(int id, string jwtToken);
        Task<List<Rejseplan>> ReadRejseplanerAsync(string jwtToken);
    }
}
