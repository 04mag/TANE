using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Application.Dtos;

namespace TANE.Persistence.Repositories
{
    public class RejsePlanRepository : IRejsePlanRepository
    {
        private readonly IHttpClientFactory _factory;

        public RejsePlanRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateRejseplan(RejseplanCreateDto rejseplan, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // POST til baseAddress/“rejseplan”/rejseplan
            var response = await client.PostAsJsonAsync("rejseplan", rejseplan);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteRejseplan(int rejseplanId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // DELETE til baseAddress/“rejseplan”/rejseplan
            var response = await client.DeleteAsync($"rejseplan/{rejseplanId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<RejseplanReadDto>> ReadAllRejseplaner(string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<RejseplanReadDto>
            var tours = await client.GetFromJsonAsync<List<RejseplanReadDto>>("rejseplan");

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<RejseplanReadDto>();
        }

        public async Task<RejseplanReadDto> ReadRejseplanById(int rejseplanId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Problemet: du henter altid "…/rejseplan/rejseplan" uden ID
            var rejseplan = await client.GetFromJsonAsync<RejseplanReadDto>($"rejseplan/{rejseplanId}");

            return rejseplan ?? new RejseplanReadDto();
        }

        public async Task<bool> UpdateRejseplan(int id, RejseplanUpdateDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.PutAsJsonAsync($"rejseplan/{id}", dto);

            // Returner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

        public async Task ReorderTureAsync(int rejseplanId, TurReorderDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.PostAsJsonAsync($"rejseplan/{rejseplanId}/ture/reorder", dto);

            // Returner true hvis status er 2xx
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to reorder tours: {response.StatusCode}");
            }
        }
    }
}