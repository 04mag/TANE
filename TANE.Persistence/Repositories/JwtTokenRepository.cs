using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    internal class JwtTokenRepository : IJwtTokenRepository
    {
        private readonly HttpClient _httpClient;
        public JwtTokenRepository()
        {
            _httpClient = new HttpClient
            {
                //Husk evt at ændre denne til den rigtige URL
                BaseAddress = new Uri("http://localhost:6001/auth")
            };
        }

        public async Task<JwtToken> RefreshToken(string token, string refreshToken)
        {
            var result = await _httpClient.PostAsJsonAsync("api/account/refresh-token", new { token, refreshToken });

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

        public Task<JwtToken> UserLogin(string email, string password)
        {
            var result = _httpClient.PostAsJsonAsync("api/account/login", new { email, password });
            if (result.Result.IsSuccessStatusCode)
            {
                var jwtToken = result.Result.Content.ReadFromJsonAsync<JwtToken>();
                
                if (jwtToken == null)
                {
                    throw new Exception("Failed to deserialize JWT token");
                }

                return jwtToken;
            }
            else
            {
                throw new Exception("Failed to login");
            }
        }
    }
}
