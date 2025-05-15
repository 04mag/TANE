using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Rejseplaner.Commands.Interfaces
{
    internal interface ICreateRejseplan
    {
        Task<Rejseplan> CreateRejseplanAsync(Rejseplan rejseplan, string jwtToken);
    }
}
