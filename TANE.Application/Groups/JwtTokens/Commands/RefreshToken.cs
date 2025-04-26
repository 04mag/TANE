using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.JwtTokens.Commands
{
    public class RefreshToken : IRefreshToken
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;

        public RefreshToken(IJwtTokenRepository jwtTokenRepository)
        {
            _jwtTokenRepository = jwtTokenRepository;
        }
        public async Task<JwtToken> RefreshTokenAsync(string token, string refreshToken)
        {
            try
            {
                var jwtToken = await _jwtTokenRepository.RefreshToken(token, refreshToken);
                return jwtToken;
            }
            catch (RefreshTokenExpiredException ex)
            {
                throw new RefreshTokenExpiredException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while refreshing token", ex);
            }
        }
    }
}
