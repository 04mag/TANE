using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Application.Dtos;

namespace TANE.Persistence.Repositories
{
    public class TurRepository : ITurRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<TurRepository> _logger;

        public TurRepository(
            IHttpClientFactory factory,
            IMapper mapper,
            ILogger<TurRepository> logger)
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

        public async Task<bool> CreateTur(Tur tur, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<TurCreateDto>(tur);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("tur", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under oprettelse af tur.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved oprettelse af tur.");
                throw new Exception("Der opstod en uventet fejl under oprettelsen af turen.", ex);
            }
        }

        public async Task<bool> DeleteTur(int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"tur/{turId}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under sletning af tur med ID {Id}.", turId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved sletning af tur.");
                throw new Exception("Der opstod en uventet fejl under sletningen af turen.", ex);
            }
        }

        public async Task<List<Tur>> ReadAllTure(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dtos = await client.GetFromJsonAsync<List<TurReadDto>>("tur");
                var tours = _mapper.Map<List<Tur>>(dtos);
                return tours ?? new List<Tur>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af alle ture.");
                return new List<Tur>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af ture.");
                throw new Exception("Der opstod en uventet fejl under hentning af turene.", ex);
            }
        }

        public async Task<Tur> ReadTurById(int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<TurReadDto>($"tur/{turId}");
                return _mapper.Map<Tur>(dto) ?? new Tur();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af tur med ID {Id}.", turId);
                return new Tur();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af tur.");
                throw new Exception("Der opstod en uventet fejl under hentning af turen.", ex);
            }
        }

        public async Task<bool> UpdateTur(int id, Tur tur, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<TurUpdateDto>(tur);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"tur/{id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under opdatering af tur med ID {Id}.", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved opdatering af tur.");
                throw new Exception("Der opstod en uventet fejl under opdatering af turen.", ex);
            }
        }

        public async Task AddDagToTurAsync(int turId, int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsync($"tur/{turId}/dag/{dagId}", null);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke tilføje dag til tur: {response.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under tilføjelse af dag til tur {TurId}.", turId);
                throw new Exception("Der opstod en HTTP-fejl under tilføjelse af dag til turen.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved tilføjelse af dag til tur.");
                throw;
            }
        }

        public async Task ReorderDageAsync(int turId, Dag dag, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<DagReorderDto>(dag);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync($"tur/{turId}/dage/reorder", dto);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke omrokere dage: {response.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under omrokering af dage for tur {TurId}.", turId);
                throw new Exception("Der opstod en HTTP-fejl under omrokering af dage.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved omrokering af dage.");
                throw;
            }
        }

        public async Task RemoveDagFromTurAsync(int turId, int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"tur/{turId}/dag/{dagId}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke fjerne dag fra tur: {response.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under fjernelse af dag {DagId} fra tur {TurId}.", dagId, turId);
                throw new Exception("Der opstod en HTTP-fejl under fjernelse af dag fra turen.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved fjernelse af dag fra tur.");
                throw;
            }
        }

        public async Task<ObservableCollection<Tur>> ReadAllTurePåRejseplan(int rejseplanId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.GetAsync($"tur/rejseplan/{rejseplanId}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Kunne ikke hente ture på rejseplan: {response.StatusCode}.");

                var dtos = await response.Content.ReadFromJsonAsync<ObservableCollection<TurReadDto>>();
                return _mapper.Map<ObservableCollection<Tur>>(dtos) ?? new ObservableCollection<Tur>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af ture på rejseplan {PlanId}.", rejseplanId);
                return new ObservableCollection<Tur>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af ture på rejseplan.");
                throw new Exception("Der opstod en uventet fejl under hentning af ture på rejseplanen.", ex);
            }
        }
    }
}
