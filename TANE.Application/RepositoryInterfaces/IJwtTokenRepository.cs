using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.RepositoryInterfaces
{
    public interface IJwtTokenRepository
    {
        Task<JwtToken> UserLogin(string email, string password);
        Task<JwtToken> RefreshToken(string token, string refreshToken);

        Task<bool> CreateUserAsync(string email, string password, string jwtToken);
        Task<List<User>> GetUsersAsync(string jwtToken);
        Task<bool> UpdateUserAsync(string email, string password, string jwtToken);
    }
}
