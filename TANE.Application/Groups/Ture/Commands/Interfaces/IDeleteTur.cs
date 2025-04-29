using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.Ture.Commands.Interfaces
{
    internal interface IDeleteTur
    {
        Task<bool> DeleteTurAsync(int id, string jwtToken);
    }
}
