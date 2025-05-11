using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.RepositoryInterfaces;

namespace TANE.Persistence.Repositories
{
    public class TurSkabelonRepository : ITurSkabelonRepository
    {

        private readonly IHttpClientFactory _factory;

        public TurSkabelonRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateTurSkabelon(TurSkabelonCreateDto tur, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("skabelon");

            // sæt dit Bearer-token
            SetJwtToken(client, jwtToken);
            // POST til baseAddress/“rejseplan”/tur
            var response = await client.PostAsJsonAsync("api/TurSkabelon", tur);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteTurSkabelon(int turId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);
            // DELETE til baseAddress/“rejseplan”/tur
            var response = await client.DeleteAsync($"api/TurSkabelon/{turId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<TurSkabelonReadDto>> ReadAllTurSkabeloner(string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            // Hent og deserialiser direkte til List<TurSkabelonReadDto>
            var tours = await client.GetFromJsonAsync<List<TurSkabelonReadDto>>("api/TurSkabelon");

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<TurSkabelonReadDto>();
        }

        public async Task<TurSkabelonReadDto> ReadTurSkabelonById(int turId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            // Problemet: du henter altid "…/rejseplan/tur" uden ID
            var tur = await client.GetFromJsonAsync<TurSkabelonReadDto>($"api/TurSkabelon/{turId}");

            return tur ?? new TurSkabelonReadDto();
        }


        public async Task<bool> UpdateTurSkabelon(int id, TurSkabelonUpdateDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            // PUT til https://.../rejseplan/tur/{id} med dto som JSON-body
            var response = await client.PutAsJsonAsync($"api/TurSkabelon/{id}", dto);

            // Returner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

        public async Task AddDagToTurSkabelonAsync(int turId, int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsync(
                $"api/TurSkabelon/{turId}/dag/{dagId}",
                content: null
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsJsonAsync(
                $"api/TurSkabelon/{turId}/dage/reorder",
                dto
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveDagFromTurSkabelonAsync(int turId, int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.DeleteAsync(
                $"api/TurSkabelon/{turId}/dag/{dagId}"
            );
            response.EnsureSuccessStatusCode();

        }

        public async Task<ObservableCollection<TurSkabelonReadDto>> ReadAllTurSkabelonePåRejseplan(int rejseplanId,
            string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.GetAsync($"api/TurSkabelon/rejseplan/{rejseplanId}");
            response.EnsureSuccessStatusCode();
            var tours = await response.Content.ReadFromJsonAsync<ObservableCollection<TurSkabelonReadDto>>();
            return tours ?? new ObservableCollection<TurSkabelonReadDto>();
        }
    }
}

