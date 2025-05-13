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
        Task UpdateUserAsync(string email, string newPassword, string jwtToken);
        Task<bool> UpdatePasswordAsync(string jwtToken, string currentPassword, string newPassword);
    }
}
