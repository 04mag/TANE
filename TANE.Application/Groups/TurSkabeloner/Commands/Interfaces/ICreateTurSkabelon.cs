using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.TurSkabeloner.Commands.Interfaces
{
    internal interface ICreateTurSkabelon
    {
        Task<TurSkabelon> CreateTurSkabelonAsync(TurSkabelon turSkabelon);
    }
}
