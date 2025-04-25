using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class JwtTokenRepository : IJwtTokenRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public JwtTokenRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<JwtToken> RefreshToken(string token, string refreshToken)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("auth"))
            {
                var result = await httpClient.PostAsJsonAsync("api/account/refresh-token", new { token, refreshToken });

                if (result.IsSuccessStatusCode)
                {

                    var jwtToken = await result.Content.ReadFromJsonAsync<JwtToken>();

                    if (jwtToken == null)
                    {
                        throw new Exception("Failed to deserialize JWT token");
                    }

                    return jwtToken;
                }
                else
                {
                    throw new Exception("Failed to refresh token");
                }
            }
        }

        public async Task<JwtToken> UserLogin(string email, string password)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("auth"))
            {
                var result = await httpClient.PostAsJsonAsync("api/account/login", new { email, password });
                if (result.IsSuccessStatusCode)
                {
                    var jwtToken = await result.Content.ReadFromJsonAsync<JwtToken>();

                    if (jwtToken == null)
                    {
                        throw new Exception("Failed to deserialize JWT token");
                    }

                    return jwtToken;
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new NotAuthorizedException("Credentials provided were invalid");
                }
                else
                {
                    throw new Exception("Failed to login");
                }
            }
        }
    }
}
