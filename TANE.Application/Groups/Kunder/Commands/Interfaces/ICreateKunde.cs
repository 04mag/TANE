using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Commands.Interfaces
{
    internal interface ICreateKunde
    {
        Task<Kunde> CreateKundeAsync(Kunde kunde);
    }
}
