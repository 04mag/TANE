using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.Common.Exceptions;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class RejseplanSkabelonRepository : IRejseplanSkabelonRepository
    {
        private readonly IHttpClientFactory _factory;

        public RejseplanSkabelonRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<RejseplanSkabelon> CreateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsJsonAsync("api/RejseplanSkabelon", rejseplanSkabelon);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RejseplanSkabelon>();

                return result!;
            }
            else
            {
                throw new Exception("Serveren returnerede en intern fejl. Prøv igen senere.");
            }
        }

        public async Task<bool> DeleteRejseplanSkabelonAsync(int id, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.DeleteAsync($"api/RejseplanSkabelon/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<RejseplanSkabelon>> ReadAllRejseplanSkabelonerAsync(string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var result = await client.GetFromJsonAsync<List<RejseplanSkabelon>>("api/RejseplanSkabelon");

            return result!;
        }

        public async Task<RejseplanSkabelon> ReadRejseplanSkabelonByIdAsync(int id, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var result = await client.GetFromJsonAsync<RejseplanSkabelon>($"api/RejseplanSkabelon/{id}");

            return result!;
        }

        public async Task<RejseplanSkabelon> UpdateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.PutAsJsonAsync($"api/TurSkabelon/{rejseplanSkabelon.Id}", rejseplanSkabelon);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RejseplanSkabelon>();
                return result!;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new ConflictException("Der opstod en konflikt ved opdatering af turskabelonen. Prøv igen eller gendinlæs siden.");
            }
            else
            {
                throw new ArgumentException("Serveren returnerede en intern fejl. Prøv igen senere.");
            }
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }

    }
}
