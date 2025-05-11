using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Interfaces
{
    public interface IUpdateUser
    {
       Task<bool> UpdateUserAsync(Guid userId, string NewPassword, string jwtToken);
    }
}
