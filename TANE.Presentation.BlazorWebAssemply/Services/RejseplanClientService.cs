// RejseplanClient.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TANE.Application.Dtos;
using TANE.Domain.Entities;

namespace TANE.Presentation.BlazorWebAssemply.Services
{

    public class RejseplanClientService : IRejseplanClientService
    {
        private readonly HttpClient _http;

        public RejseplanClientService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Rejseplan>> GetAllAsync()
            => await _http.GetFromJsonAsync<IEnumerable<Rejseplan>>("rejseplan");

        public async Task<Rejseplan> GetByIdAsync(int id)
            => await _http.GetFromJsonAsync<Rejseplan>($"rejseplan/{id}");

        public async Task<Rejseplan> CreateAsync(Rejseplan dto)
            => await _http.PostAsJsonAsync("rejseplan", dto)
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<Rejseplan>())
                .Unwrap();

        public async Task<Rejseplan> UpdateAsync(int id, Rejseplan dto)
            => await _http.PutAsJsonAsync($"rejseplan/{id}", dto)
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<Rejseplan>())
                .Unwrap();

        public async Task DeleteAsync(int id, byte[] rowVersion)
        {
            // RowVersion pakkes i body eller som header efter dit API-design:
            var request = new HttpRequestMessage(HttpMethod.Delete, $"rejseplan/{id}")
            {
                Content = JsonContent.Create(rowVersion)
            };
            await _http.SendAsync(request);
        }

        public async Task AddTurToRejseplanAsync(int rejseplanId, int turId)
        {
            var response = await _http.PostAsync($"rejseplan/{rejseplanId}/tur/{turId}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task ReorderTureAsync(int rejseplanId, TurReorderDto dto)
        {
            var response = await _http.PostAsJsonAsync($"rejseplan/{rejseplanId}/ture/reorder", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveTurFromRejseplanAsync(int rejseplanId, int turId)
        {
            var response = await _http.DeleteAsync($"rejseplan/{rejseplanId}/tur/{turId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
