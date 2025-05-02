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
        public class TurRepository : ITurRepository
        {

        private readonly IHttpClientFactory _factory;

        public TurRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateTur(TurCreateDto tur, string jwtToken) 
        { 
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // POST til baseAddress/“rejseplan”/tur
            var response = await client.PostAsJsonAsync("tur", tur);
            return response.IsSuccessStatusCode;
        }
        

    public async Task<bool> DeleteTur(int turId, string jwtToken)
            {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // DELETE til baseAddress/“rejseplan”/tur
            var response = await client.DeleteAsync($"tur/{turId}");
            return response.IsSuccessStatusCode;
            }


        public async Task<List<TurReadDto>> ReadAllTure(string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<TurReadDto>
            var tours = await client.GetFromJsonAsync<List<TurReadDto>>("tur");

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<TurReadDto>();
        }

        public async Task<TurReadDto> ReadTurById(int turId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Problemet: du henter altid "…/rejseplan/tur" uden ID
            var tur = await client.GetFromJsonAsync<TurReadDto>($"tur/{turId}");

            return tur ?? new TurReadDto();
        }


        public async Task<bool> UpdateTur(int id, TurUpdateDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // PUT til https://.../rejseplan/tur/{id} med dto som JSON-body
            var response = await client.PutAsJsonAsync($"tur/{id}", dto);

            // Returner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

        public async Task AddDagToTurAsync(int turId, int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsync(
                $"tur/{turId}/dag/{dagId}",
                content: null
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsJsonAsync(
                $"tur/{turId}/dage/reorder",
                dto
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveDagFromTurAsync(int turId, int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            SetJwtToken(client, jwtToken);

            var response = await client.DeleteAsync(
                $"tur/{turId}/dag/{dagId}"
            );
            response.EnsureSuccessStatusCode();
        }
    }
    }
