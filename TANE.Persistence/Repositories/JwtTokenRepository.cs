using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.Groups.JwtTokens.Commands;
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

        public async Task<bool> CreateUserAsync(string email, string password, string jwtToken)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("auth"))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

                var result = await httpClient.PostAsJsonAsync("api/Admin/register", new { email, password });

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized || result.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new NotAuthorizedException("Unauthorized");
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    throw new ConflictException("User already exists");
                }
                else
                {
                    throw new Exception("Failed to create user");
                }
            }
        }

        public async Task<JwtToken> RefreshToken(string accessToken, string refreshToken)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("auth"))
            {
                var result = await httpClient.PostAsJsonAsync("api/Account/refresh-token", new { accessToken, refreshToken });

                if (result.IsSuccessStatusCode)
                {

                    var jwtToken = await result.Content.ReadFromJsonAsync<JwtToken>();

                    if (jwtToken == null)
                    {
                        throw new Exception("Failed to deserialize JWT token");
                    }

                    return jwtToken;
                }
                else if ((int)result.StatusCode == 498)
                {
                    throw new RefreshTokenExpiredException("Invalid token");
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
                    throw new NotAuthorizedException("Invalid credentials");
                }
                else
                {
                    throw new Exception("Failed to login");
                }
            }
        }

        public async Task<List<User>> GetUsersAsync(string jwtToken)
        {
            var client = _httpClientFactory.CreateClient("auth");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<RejseplanReadDto>
            var users = await client.GetFromJsonAsync<List<User>>("api/Admin/users");
            return users ?? new List<User>(); 
        }
        

    }
}
