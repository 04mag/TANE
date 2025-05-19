using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Application.Dtos;
using System.Collections.ObjectModel;
using System.Text;

namespace TANE.Persistence.Repositories
{
    public class DagRepository : IDagRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<DagRepository> _logger;

        public DagRepository(
            IHttpClientFactory factory,
            IMapper mapper,
            ILogger<DagRepository> logger)
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

        public async Task<bool> CreateDagAsync(Dag dag, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<DagCreateDto>(dag);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("dag", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under oprettelse af dag.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved oprettelse af dag.");
                throw new ArgumentException("Der opstod en uventet fejl under oprettelsen af dagen.", ex);
            }
        }

        public async Task<bool> DeleteDagAsync(int dagId, byte[] rowVersion, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                // 1) Konverter byte[] til Base64
                var rowVersionBase64 = Convert.ToBase64String(rowVersion);

                // 2) URL‐escape Base64‐strengen
                var encoded = Uri.EscapeDataString(rowVersionBase64);

                // 3) Sæt rowVersion på som query‐parameter
                var requestUri = $"dag/{dagId}?rowVersion={encoded}";

                var response = await client.DeleteAsync(requestUri);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under sletning af dag med ID {Id}.", dagId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved sletning af dag.");
                throw new ArgumentException("Der opstod en uventet fejl under sletningen af dagen.", ex);
            }
        }

        public async Task<List<Dag>> ReadAllDageAsync(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dtos = await client.GetFromJsonAsync<List<DagReadDto>>("dag");
                var items = _mapper.Map<List<Dag>>(dtos);
                return items ?? new List<Dag>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af alle dage.");
                return new List<Dag>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af dage.");
                throw new ArgumentException("Der opstod en uventet fejl under hentning af dagene.", ex);
            }
        }

        public async Task<Dag> ReadDagByIdAsync(int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<DagReadDto>($"dag/{dagId}");
                return _mapper.Map<Dag>(dto) ?? new Dag();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af dag med ID {Id}.", dagId);
                return new Dag();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af dag.");
                throw new ArgumentException("Der opstod en uventet fejl under hentning af dagen.", ex);
            }
        }

        public async Task<bool> UpdateDagAsync(int id, Dag dag, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<DagUpdateDto>(dag);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"dag/{id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under opdatering af dag med ID {Id}.", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved opdatering af dag.");
                throw new ArgumentException("Der opstod en uventet fejl under opdatering af dagen.", ex);
            }
        }

        public async Task<ObservableCollection<Dag>> ReadAllDagePåTur(int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.GetAsync($"Dag/tur/{turId}");
                if (!response.IsSuccessStatusCode)
                    throw new ArgumentException($"Kunne ikke hente dage på tur: {response.StatusCode}.");

                var dtos = await response.Content.ReadFromJsonAsync<ObservableCollection<DagReadDto>>();
                return _mapper.Map<ObservableCollection<Dag>>(dtos) ?? new ObservableCollection<Dag>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af dage på tur {TurId}.",turId);
                return new ObservableCollection<Dag>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af dage på tur.");
                throw new ArgumentException("Der opstod en uventet fejl under hentning af dage på turen.", ex);
            }
        }
    }
}
