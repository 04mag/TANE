using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class TurSkabelonRepository : ITurSkabelonRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<TurSkabelonRepository> _logger;

        public TurSkabelonRepository(
            IHttpClientFactory factory,
            IMapper mapper,
            ILogger<TurSkabelonRepository> logger)
        {
            _factory = factory;
            _mapper = mapper;
            _logger = logger;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }

        public async Task<bool> CreateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<TurSkabelonCreateDto>(tur);
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("api/TurSkabelon", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under oprettelse af turskabelon.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved oprettelse af turskabelon.");
                throw new Exception("Der opstod en uventet fejl under oprettelsen af turskabelonen.", ex);
            }
        }

        public async Task<bool> DeleteTurSkabelon(int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"api/TurSkabelon/{turId}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under sletning af turskabelon med ID {Id}.", turId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved sletning af turskabelon.");
                throw new Exception("Der opstod en uventet fejl under sletningen af turskabelonen.", ex);
            }
        }

        public async Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var dtos = await client.GetFromJsonAsync<List<TurSkabelonReadDto>>("api/TurSkabelon");
                var skabeloner = _mapper.Map<List<TurSkabelon>>(dtos);
                return skabeloner ?? new List<TurSkabelon>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af turskabeloner.");
                return new List<TurSkabelon>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af turskabeloner.");
                throw new Exception("Der opstod en uventet fejl under hentning af turskabelonerne.", ex);
            }
        }

        public async Task<TurSkabelon> ReadTurSkabelonById(int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<TurSkabelonReadDto>($"api/TurSkabelon/{turId}");
                return _mapper.Map<TurSkabelon>(dto) ?? new TurSkabelon();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af turskabelon med ID {Id}.", turId);
                return new TurSkabelon();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af turskabelon.");
                throw new Exception("Der opstod en uventet fejl under hentning af turskabelonen.", ex);
            }
        }

        public async Task<bool> UpdateTurSkabelon(int id, TurSkabelon tur, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<TurSkabelonUpdateDto>(tur);
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"api/TurSkabelon/{id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under opdatering af turskabelon med ID {Id}.", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved opdatering af turskabelon.");
                throw new Exception("Der opstod en uventet fejl under opdatering af turskabelonen.", ex);
            }
        }

        public async Task AddDagToTurSkabelonAsync(int turId, int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsync($"api/TurSkabelon/{turId}/dag/{dagId}", null);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke tilføje dag til turskabelon: {response.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under tilføjelse af dag til turskabelon {TurId}.", turId);
                throw new Exception("Der opstod en HTTP-fejl under tilføjelse af dag til turskabelonen.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved tilføjelse af dag til turskabelon.");
                throw;
            }
        }

        public async Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync($"api/TurSkabelon/{turId}/dage/reorder", dto);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke omrokere dage for turskabelon: {response.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under omrokering af dage for turskabelon {TurId}.", turId);
                throw new Exception("Der opstod en HTTP-fejl under omrokering af dage.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved omrokering af dage for turskabelon.");
                throw;
            }
        }

        public async Task RemoveDagFromTurSkabelonAsync(int turId, int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"api/TurSkabelon/{turId}/dag/{dagId}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke fjerne dag fra turskabelon: {response.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under fjernelse af dag {DagId} fra turskabelon {TurId}.", dagId, turId);
                throw new Exception("Der opstod en HTTP-fejl under fjernelse af dag fra turskabelonen.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved fjernelse af dag fra turskabelon.");
                throw;
            }
        }

        public async Task<ObservableCollection<TurSkabelon>> ReadAllTurSkabelonePåRejseplan(int rejseplanId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.GetAsync($"api/TurSkabelon/rejseplan/{rejseplanId}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke hente turskabeloner på rejseplan: {response.StatusCode}.");

                var dtos = await response.Content.ReadFromJsonAsync<ObservableCollection<TurSkabelonReadDto>>();
                return _mapper.Map<ObservableCollection<TurSkabelon>>(dtos) ?? new ObservableCollection<TurSkabelon>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af turskabeloner på rejseplan {PlanId}.", rejseplanId);
                return new ObservableCollection<TurSkabelon>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af turskabeloner på rejseplan.");
                throw new Exception("Der opstod en uventet fejl under hentning af turskabeloner på rejseplanen.", ex);
            }
        }
    }
}
