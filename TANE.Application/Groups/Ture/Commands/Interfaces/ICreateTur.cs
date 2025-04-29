using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Ture.Commands.Interfaces
{
    internal interface ICreateTur
    {
        Task<Tur> CreateTurAsync(Tur tur, string jwtToken);
    }
}
