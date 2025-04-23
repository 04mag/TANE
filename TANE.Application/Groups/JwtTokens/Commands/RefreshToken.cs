using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.JwtTokens.Commands
{
    public class RefreshToken : IRefreshToken
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;

        public RefreshToken(IJwtTokenRepository jwtTokenRepository)
        {
            _jwtTokenRepository = jwtTokenRepository;
        }
        public async Task<string> RefreshTokenAsync(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
