using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Dage.Queries.Interfaces
{
    public interface IReadDag
    {
        Task<Dag> ReadDagAsync(int id, string jwtToken);
        Task<List<Dag>> ReadDageAsync(string jwtToken);
    }
}
