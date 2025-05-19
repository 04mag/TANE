using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.DagSkabeloner.Commands.Interfaces
{
    public interface IDeleteDagSkabelon
    {
        Task<bool> DeleteDagSkabelonAsync(int id, string jwtToken);
    }
}
