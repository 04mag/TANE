using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.JwtTokens.Commands.Interfaces
{
    public interface ICreateUser
    {
        Task CreateUserAsync(string email, string password, string jwtToken);
    }
}
