using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.RejsePlaner.Commands.Interfaces
{
    internal interface IDeleteRejsePlan
    {
        Task<bool> DeleteRejsePlanAsync(int Id, string jwtToken);
    }
}
