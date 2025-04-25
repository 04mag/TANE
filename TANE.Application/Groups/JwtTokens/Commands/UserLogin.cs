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
    public class UserLogin : IUserLogin
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;

        public UserLogin(IJwtTokenRepository jwtTokenRepository)
        {
            _jwtTokenRepository = jwtTokenRepository;
        }

        public async Task<JwtToken> LoginAsync(string email, string password)
        {
            try
            {
                var jwtToken = await _jwtTokenRepository.UserLogin(email, password);
                return jwtToken;
            }
            catch (NotAuthorizedException ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in", ex);
            }
        }
    }
}
