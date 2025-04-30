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
    internal class RejsePlanRepository : IRejsePlanRepository
    {
        private readonly HttpClient _http;

        public RejsePlanRepository(HttpClient http)
        {
            _http = http;
        }

        private void SetJwtToken(string jwtToken)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        }

        public async Task<bool> CreateRejsePlan(RejsePlan rejsePlan, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.PostAsJsonAsync("rejseplan", rejsePlan);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteRejsePlan(int rejsePlanId, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.DeleteAsync($"rejseplan/{rejsePlanId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<RejseplanReadDto>> ReadAllRejsePlans(string jwtToken)
        {
            SetJwtToken(jwtToken);
            var dtos = await _http.GetFromJsonAsync<List<RejseplanReadDto>>("rejseplan");
            return dtos;
        }

        public async Task<RejseplanReadDto> ReadRejsePlanById(int rejsePlanId, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var dto = await _http.GetFromJsonAsync<RejseplanReadDto>($"rejseplan/{rejsePlanId}");
            return dto;
        }

        public async Task<bool> UpdateRejsePlan(int id, RejseplanUpdateDto dto, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.PutAsJsonAsync($"rejseplan/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task AddTurToRejseplanAsync(int rejseplanId, int turId, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.PostAsync($"rejseplan/{rejseplanId}/tur/{turId}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task ReorderTureAsync(int rejseplanId, TurReorderDto dto, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.PostAsJsonAsync($"rejseplan/{rejseplanId}/ture/reorder", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveTurFromRejseplanAsync(int rejseplanId, int turId, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.DeleteAsync($"rejseplan/{rejseplanId}/tur/{turId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
