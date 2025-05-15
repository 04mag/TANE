using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.RejseplanSkabeloner.Commands.Interfaces
{
    internal interface IDeleteRejseplanSkabelon
    {
        Task<bool> DeleteRejseplanSkabelonAsync(int id, string jwtToken);
    }
}
