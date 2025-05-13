using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.JwtTokens.Commands
{
    public class RevokeToken : IRevokeToken
    {
        private readonly IJwtTokenRepository jwtTokenRepository;

        public RevokeToken(IJwtTokenRepository jwtTokenRepository)
        {
            this.jwtTokenRepository = jwtTokenRepository;
        }

        public async Task<bool> RevokeAllTokensAsync(string jwtToken)
        {
            return await jwtTokenRepository.RevokeAllTokensAsync(jwtToken);
        }

        public async Task<bool> RevokeTokenAsync(string email, string jwtToken)
        {
            return await jwtTokenRepository.RevokeTokenAsync(email, jwtToken);
        }
    }
}
