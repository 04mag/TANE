using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TANE.Application.RepositoryInterfaces;
using TANE.Application.Dtos.Skabeloner;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class DagSkabelonRepository : IDagSkabelonRepository
    {
        private readonly IHttpClientFactory _factory;

        public DagSkabelonRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }

        public async Task<DagSkabelon> CreateDagSkabelonAsync(DagSkabelon dag, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("api/DagSkabelon", dag);

                if (response.IsSuccessStatusCode)
                {
                    var createdDag = await response.Content.ReadFromJsonAsync<DagSkabelon>();
                    
                    return createdDag!;
                }
                else
                {
                    throw new Exception("Serveren returnerede en intern fejl. Prøv igen senere.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under oprettelsen af dagsskabelonen.", ex);
            }
        }

        public async Task<bool> DeleteDagSkabelonAsync(int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.DeleteAsync($"api/DagSkabelon/{dagId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<DagSkabelon>> ReadAllDagSkabeloneAsync(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var result = await client.GetFromJsonAsync<List<DagSkabelon>>("api/DagSkabelon");

                if (result == null)
                {
                    return new List<DagSkabelon>();
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under hentning af dagsskabeloner.", ex);
            }
        }

        public async Task<DagSkabelon> ReadDagSkabelonByIdAsync(int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var result = await client.GetFromJsonAsync<DagSkabelon>($"api/DagSkabelon/{dagId}");

                if (result == null)
                {
                    throw new Exception("Dagsskabelon ikke fundet.");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under hentning af dagsskabelonen.", ex);
            }
        }

        public async Task<DagSkabelon> UpdateDagSkabelonAsync(int id, DagSkabelon dag, string jwtToken)
        {
            try
            {

                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"api/DagSkabelon/{id}", dag);

                if (response.IsSuccessStatusCode)
                {
                    var updatedDag = await response.Content.ReadFromJsonAsync<DagSkabelon>();

                    return updatedDag;
                }
                else
                {
                    throw new Exception("Serveren returnerede en intern fejl. Prøv igen senere.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under opdatering af dagsskabelonen.", ex);
            }
        }
    }
}
