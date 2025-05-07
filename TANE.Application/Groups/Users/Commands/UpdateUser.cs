using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.Groups.Users.Interfaces;

namespace TANE.Application.Groups.Users.Commands
{
    public class UpdateUser : IUpdateUser
    {
        private readonly IHttpClientFactory _factory;
        public UpdateUser(IHttpClientFactory factory) => _factory = factory;

        public async Task<bool> UpdateUserAsync(Guid userId, string newPassword, string jwtToken)
        {
            using var client = _factory.CreateClient("auth");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

            var result = await client.PutAsJsonAsync("api/Admin/users/change-password",
                new { userId, password = newPassword });

            if (result.IsSuccessStatusCode) return true;
            if (result.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                throw new NotAuthorizedException("Ikke autoriseret til at ændre password.");
            if (result.StatusCode == HttpStatusCode.Conflict)
                throw new ConflictException("Kan ikke ændre password for denne bruger.");
            throw new Exception("Serverfejl ved password-ændring.");
        }
    }
}