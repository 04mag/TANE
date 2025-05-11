using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Groups.Users.Queries.Interfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Queries
{

    public class GetUsers : IGetUsers
    {
        private readonly HttpClient _http;

        public GetUsers(HttpClient http)
        {
            _http = http;
        }

        public async Task<IReadOnlyList<User>> GetUsersAsync(string jwtToken)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Henter listen
            return await _http
                .GetFromJsonAsync<List<User>>("api/Admin/users")
                   ?? new List<User>();
        }
    }
}
