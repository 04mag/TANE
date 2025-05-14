using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.Rejseplaner.Commands.Interfaces
{
    internal interface IDeleteRejseplan
    {
        Task<bool> DeleteRejseplanAsync(int Id, string jwtToken);
    }
}
