using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Application.Groups.JwtTokens.Commands.Interfaces
{
    public interface IRefreshToken
    {
        Task<string> RefreshTokenAsync(string token, string refreshToken);
    }
}
