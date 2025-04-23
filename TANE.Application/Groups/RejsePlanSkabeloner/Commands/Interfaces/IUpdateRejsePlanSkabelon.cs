using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejsePlanSkabeloner.Commands.Interfaces
{
    internal interface IUpdateRejsePlanSkabelon
    {
        Task<RejsePlanSkabelon> UpdateRejsePlanSkabelonAsync(RejsePlanSkabelon rejsePlanSkabelon);
    }
}
