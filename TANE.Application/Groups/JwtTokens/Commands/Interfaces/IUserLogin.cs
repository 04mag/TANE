using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.JwtTokens.Commands.Interfaces
{
    public interface IUserLogin
    {
        Task<User> LoginAsync(string email, string password);
    }
}
