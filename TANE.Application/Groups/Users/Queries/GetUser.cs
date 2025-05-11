using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.Groups.Users.Queries.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Commands
{
    public class GetUser : IGetUser
    {
        private readonly HttpClient _http;
        public GetUser(HttpClient http) => _http = http;

        public async Task<User> GetUserByIdAsync(Guid userId, string jwtToken)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var user = await _http
                .GetFromJsonAsync<User>($"api/Admin/users/{userId}");

            if (user is null)
                throw new KeyNotFoundException($"Bruger {userId} ikke fundet.");

            return user;
        }
    }




}