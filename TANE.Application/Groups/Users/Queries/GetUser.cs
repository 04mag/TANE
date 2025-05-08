using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.Groups.Users.Commands.Interfaces;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Commands
{
    public class GetUser : IGetUser
    {
        private readonly IHttpClientFactory _factory;
        public GetUser(IHttpClientFactory factory) => _factory = factory;

        public async Task<User> GetUserByIdAsync(Guid userId, string jwtToken)
        {
            using var client = _factory.CreateClient("auth");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

            // Antag at API’et returnerer User-objektet
            var user = await client.GetFromJsonAsync<User>($"api/Admin/users/{userId}");
            return user!;
        }
    }
    
}