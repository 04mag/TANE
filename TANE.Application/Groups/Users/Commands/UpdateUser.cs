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
        private readonly HttpClient _http;
        public UpdateUser(HttpClient http) => _http = http;

        public async Task<bool> UpdateUserAsync(Guid userId, string newPassword, string jwtToken)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await _http.PutAsJsonAsync("api/Admin/users/change-password",
                new { userId, password = newPassword });

            if (response.StatusCode == HttpStatusCode.Conflict)

                throw new ConflictException("Kan ikke ændre password for denne bruger.");

            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                     response.StatusCode == HttpStatusCode.Forbidden)

                throw new NotAuthorizedException("Ikke autoriseret til at ændre password.");

            else if (!response.IsSuccessStatusCode)

                throw new Exception("Serverfejl ved password‐ændring.");

            return true;
        }
    }
}