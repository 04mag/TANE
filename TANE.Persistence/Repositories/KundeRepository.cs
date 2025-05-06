using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using System.Net.Http.Json;
using TANE.Application.Common.Exceptions;
using System.Text;
using System.Net.Http.Headers;

namespace TANE.Persistence.Repositories
{
    internal class KundeRepository : IKundeRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public KundeRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }
        public async Task<Kunde> CreateKundeAsync(Kunde kunde, string jwtToken)
        {
            var client = _httpClientFactory.CreateClient("kunde");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsJsonAsync("api/Kunde", kunde);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Kunde>();
            }
            else
            {
                throw new Exception("Fejl ved oprettelse af kunde");
            }
        }

        public async Task<bool> DeleteKundeAsync(int id, string jwtToken)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("kunde"))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await httpClient.DeleteAsync($"api/Kunde/{id}");

                return response.IsSuccessStatusCode;
            }
        }


        public async Task<List<Kunde>> ReadAllKunderAsync(string jwtToken)
        {
            var client = _httpClientFactory.CreateClient("kunde");
            
            SetJwtToken(client, jwtToken);
            var response = await client.GetAsync("api/Kunde");
            if (response.IsSuccessStatusCode) 
            {
                return await response.Content.ReadFromJsonAsync<List<Kunde>>();
            }
            else
            {
                throw new Exception("Failed to list all kunder");
            } 
        }
        

        public async Task<Kunde> ReadKundeByIdAsync(int id, string jwtToken)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient("kunde"))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                
                var response = await httpClient.GetAsync($"api/Kunde/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Kunde>();
                }
                else
                {
                    throw new Exception("Fejl ved hentning af kunde");
                }
            }

        }

        public async Task<Kunde> UpdateKundeAsync(Kunde kunde, string jwtToken)
        {
            using(HttpClient httpClient = _httpClientFactory.CreateClient("kunde"))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                
                var result = await httpClient.PutAsJsonAsync("api/Kunde/update", kunde);
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadFromJsonAsync<Kunde>();
                }
                else
                {
                    throw new Exception("Fejl ved opdatering af kunde");
                }
            }
        }
    }
}
