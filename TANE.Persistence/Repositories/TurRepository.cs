    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using AutoMapper;
    using TANE.Application.RepositoryInterfaces;
    using TANE.Domain.Entities;
    using TANE.Rejseplan.Application.Dtos;

    namespace TANE.Persistence.Repositories
    {
        internal class TurRepository : ITurRepository
        {
            private readonly HttpClient _http;
            private readonly IMapper _mapper;

            public TurRepository(HttpClient http, IMapper mapper)
            {
                _http = http;
                _mapper = mapper;
            }

            private void SetJwtToken(string jwtToken)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            public async Task<bool> CreateTur(Tur tur, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var dto = _mapper.Map<TurCreateDto>(tur);
                var response = await _http.PostAsJsonAsync("tur", dto);
                return response.IsSuccessStatusCode;
            }

            public async Task<bool> DeleteTur(int turId, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var response = await _http.DeleteAsync($"tur/{turId}");
                return response.IsSuccessStatusCode;
            }

            public async Task<List<Tur>> ReadAllTure(string jwtToken)
            {
                SetJwtToken(jwtToken);
                var dtos = await _http.GetFromJsonAsync<List<TurReadDto>>("tur");
                return _mapper.Map<List<Tur>>(dtos);
            }

            public async Task<Tur> ReadTurById(int turId, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var dto = await _http.GetFromJsonAsync<TurReadDto>($"tur/{turId}");
                return _mapper.Map<Tur>(dto);
            }

            public async Task<bool> UpdateTur(int id, TurUpdateDto dto, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var response = await _http.PutAsJsonAsync($"tur/{id}", dto);
                return response.IsSuccessStatusCode;
            }

            public async Task AddDagToTurAsync(int turId, int dagId, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var response = await _http.PostAsync($"tur/{turId}/dag/{dagId}", null);
                response.EnsureSuccessStatusCode();
            }

            public async Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var response = await _http.PostAsJsonAsync($"tur/{turId}/dage/reorder", dto);
                response.EnsureSuccessStatusCode();
            }

            public async Task RemoveTurFromTurAsync(int turId, int dagId, string jwtToken)
            {
                SetJwtToken(jwtToken);
                var response = await _http.DeleteAsync($"tur/{turId}/dag/{dagId}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
