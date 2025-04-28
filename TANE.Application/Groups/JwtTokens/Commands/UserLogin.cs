using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public async Task<User> LoginAsync(string email, string password)
        {
            try
            {
                var result = await _jwtTokenRepository.UserLogin(email, password);

                var encryptedToken = result.Token;
                
                var handler = new JwtSecurityTokenHandler();

                var decryptedToken = handler.ReadJwtToken(encryptedToken);

                var claims = decryptedToken.Claims.ToList();

                var useremail = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
                var userroles = claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.ToList();


                //setup user object
                User user = new User
                {
                    Email = useremail,
                    Token = result.Token,
                    RefreshToken = result.RefreshToken,
                    Expiration = result.Expiration
                };

                foreach (var role in userroles)
                {
                    user.Roles.Add(role.Value);
                }

                return user;
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
