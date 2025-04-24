using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Queries.Interfaces
{
    internal interface IReadKunde
    {
        Task<Kunde> GetKundeByIdAsync(int kundeId);
        Task<List<Kunde>> GetAllKunderAsync();
    }
}
