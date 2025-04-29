using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Dage.Commands.Interfaces
{
    internal interface IUpdateDag
    {
        Task<Dag> UpdateDagAsync(Dag dag, string jwtToken);
    }
}
