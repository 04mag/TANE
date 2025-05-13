using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.Groups.Users.Interfaces;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Application.Groups.Users.Commands
{
    public class UpdateUser : IUpdateUser
    {

        private readonly IJwtTokenRepository _jwtTokenRepository;

        public UpdateUser(IJwtTokenRepository jwtTokenRepository)
        {
            this._jwtTokenRepository = jwtTokenRepository;
        }

        public async Task<bool> UpdatePasswordAsync(string jwtToken, string currentPassword, string newPassword)
        {
            try
            {
                return await _jwtTokenRepository.UpdatePasswordAsync(jwtToken, currentPassword, newPassword);
            }
            catch
            {
                return false;
            }
        }

        public async Task UpdateUserAsync(string email, string password, string jwtToken)
        {
            await _jwtTokenRepository.UpdateUserAsync(email, password, jwtToken);
        }
    }
}