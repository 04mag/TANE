using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.JwtTokens.Commands.Interfaces
{
    public interface IRevokeToken
    {
        Task<bool> RevokeTokenAsync(string email, string jwtToken);
        Task<bool> RevokeAllTokensAsync(string jwtToken);
    }
}
