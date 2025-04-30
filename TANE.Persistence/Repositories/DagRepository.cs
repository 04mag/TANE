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
    internal class DagRepository : IDagRepository
    {
        private readonly HttpClient _http;

        public DagRepository(HttpClient http)
        {
            _http = http;
        }

        private void SetJwtToken(string jwtToken)
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        }

        public async Task<bool> CreateDagAsync(DagCreateDto dag, string jwtToken)
        {
            SetJwtToken(jwtToken);
           
            var response = await _http.PostAsJsonAsync("dag", dag);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDagAsync(int dagId, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.DeleteAsync($"dag/{dagId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<DagReadDto>> ReadAllDageAsync(string jwtToken)
        {
            SetJwtToken(jwtToken);
            var dtos = await _http.GetFromJsonAsync<List<DagReadDto>>("dag");
            return dtos;
        }

        public async Task<DagReadDto> ReadDagByIdAsync(int dagId, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var dto = await _http.GetFromJsonAsync<DagReadDto>($"dag/{dagId}");
            return dto;
        }

        public async Task<bool> UpdateDagAsync(int id, DagUpdateDto dto, string jwtToken)
        {
            SetJwtToken(jwtToken);
            var response = await _http.PutAsJsonAsync($"dag/{id}", dto);
            return response.IsSuccessStatusCode;
        }

    }
}
