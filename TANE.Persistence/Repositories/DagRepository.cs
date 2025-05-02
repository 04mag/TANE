using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Rejseplan.Application.Dtos;

namespace TANE.Persistence.Repositories
{
    public class DagRepository : IDagRepository
    {

        private readonly IHttpClientFactory _factory;

        public DagRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateDagAsync(DagCreateDto dag, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // POST til baseAddress/“rejseplan”/dag
            var response = await client.PostAsJsonAsync("dag", dag);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteDagAsync(int dagId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // DELETE til baseAddress/“rejseplan”/dag
            var response = await client.DeleteAsync("dag");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<DagReadDto>> ReadAllDageAsync(string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<DagReadDto>
            var tours = await client.GetFromJsonAsync<List<DagReadDto>>("dag");

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<DagReadDto>();
        }

        public async Task<DagReadDto> ReadDagByIdAsync(int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<DagReadDto>
            var dag = await client.GetFromJsonAsync<DagReadDto>("dag");

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dag ?? new DagReadDto();

        }

        public async Task<bool> UpdateDagAsync(int id, DagUpdateDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // PUT til https://.../rejseplan/dag/{id} med dto som JSON-body
            var response = await client.PutAsJsonAsync($"dag/{id}", dto);

            // Redagner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

      
    }
}
