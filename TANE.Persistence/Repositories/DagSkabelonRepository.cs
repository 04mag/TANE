using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using TANE.Application.RepositoryInterfaces;
using TANE.Application.Dtos.Skabeloner;

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


        public async Task<bool> CreateDagSkabelonAsync(DagSkabelonCreateDto dag, string jwtToken)
        {
        
            var client = _factory.CreateClient("skabelon");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        
            var response = await client.PostAsJsonAsync("api/DagSkabelon", dag);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteDagSkabelonAsync(int dagId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("skabelon", ...)
            var client = _factory.CreateClient("skabelon");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        
            var response = await client.DeleteAsync($"api/DagSkabelon/{dagId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<DagSkabelonReadDto>> ReadAllDagSkabeloneAsync(string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<DagSkabelonReadDto>
            var dage = await client.GetFromJsonAsync<List<DagSkabelonReadDto>>("api/DagSkabelon");

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dage ?? new List<DagSkabelonReadDto>();
        }

        public async Task<DagSkabelonReadDto> ReadDagSkabelonByIdAsync(int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<DagSkabelonReadDto>
            var dag = await client.GetFromJsonAsync<DagSkabelonReadDto>($"api/DagSkabelon/{dagId}");


            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dag ?? new DagSkabelonReadDto();

        }

        public async Task<bool> UpdateDagSkabelonAsync(int id, DagSkabelonUpdateDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
            
            var response = await client.PutAsJsonAsync($"api/DagSkabelon/{id}", dto);

            // Redagner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }


    }
}
