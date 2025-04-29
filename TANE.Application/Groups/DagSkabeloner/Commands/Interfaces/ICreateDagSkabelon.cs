using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.DagSkabeloner.Commands.Interfaces
{
    internal interface ICreateDagSkabelon
    {
        Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dagSkabelon, string jwtToken);
    }
}
