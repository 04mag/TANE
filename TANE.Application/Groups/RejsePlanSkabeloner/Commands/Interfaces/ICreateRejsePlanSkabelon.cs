using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.RejseplanSkabeloner.Commands.Interfaces
{
    internal interface ICreateRejseplanSkabelon
    {
        Task<bool> CreateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken);
    }
}
