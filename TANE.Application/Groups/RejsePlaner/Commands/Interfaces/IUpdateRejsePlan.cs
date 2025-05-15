using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Rejseplaner.Commands.Interfaces
{
    internal interface IUpdateRejseplan
    {
        Task<Rejseplan> UpdateRejseplanAsync(Rejseplan rejseplan, string jwtToken);
    }
}
