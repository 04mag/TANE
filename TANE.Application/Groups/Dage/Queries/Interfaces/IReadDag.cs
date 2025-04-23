using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Dage.Queries.Interfaces
{
    internal interface IReadDag
    {
        Task<Dag> ReadDagAsync(int id);
        Task<List<Dag>> ReadDageAsync();
    }
}
