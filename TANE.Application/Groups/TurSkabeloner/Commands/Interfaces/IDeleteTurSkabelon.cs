using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.TurSkabeloner.Commands.Interfaces
{
    internal interface IDeleteTurSkabelon
    {
        Task<bool> DeleteTurSkabelonAsync(int id, string jwtToken);
    }
}
