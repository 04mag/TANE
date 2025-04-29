using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Commands.Interfaces
{
    internal interface IUpdateTur
    {
        Task<Tur> UpdateTurAsync(Tur tur, string jwtToken);
    }
}
