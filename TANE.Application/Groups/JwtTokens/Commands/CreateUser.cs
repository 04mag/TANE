using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.JwtTokens.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.JwtTokens.Commands
{
    public class CreateUser : ICreateUser
    {
        private readonly IJwtTokenRepository _jwtTokenRepository;

        public CreateUser(IJwtTokenRepository jwtTokenRepository)
        {
            this._jwtTokenRepository = jwtTokenRepository;
        }

        public async Task CreateUserAsync(string email, string password, string jwtToken)
        {
            await _jwtTokenRepository.CreateUserAsync(email, password, jwtToken);
        }
    }
}
