using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Dage.Commands.Interfaces
{
    internal interface IDeleteDag
    {
        Task<bool> DeleteDagAsync(int id);
    }
}
