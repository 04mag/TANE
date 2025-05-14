using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TANE.Application.RepositoryInterfaces;
using TANE.Application.Dtos.Skabeloner;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class DagSkabelonRepository : IDagSkabelonRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<DagSkabelonRepository> _logger;

        public DagSkabelonRepository(
            IHttpClientFactory factory,
            IMapper mapper,
            ILogger<DagSkabelonRepository> logger)
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

        public async Task<bool> CreateDagSkabelonAsync(DagSkabelon dag, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<DagSkabelonCreateDto>(dag);
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("api/DagSkabelon", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under oprettelse af dagsskabelon.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved oprettelse af dagsskabelon.");
                throw new Exception("Der opstod en uventet fejl under oprettelsen af dagsskabelonen.", ex);
            }
        }

        public async Task<bool> DeleteDagSkabelonAsync(int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"api/DagSkabelon/{dagId}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under sletning af dagsskabelon med ID {Id}.", dagId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved sletning af dagsskabelon.");
                throw new Exception("Der opstod en uventet fejl under sletningen af dagsskabelonen.", ex);
            }
        }

        public async Task<List<DagSkabelon>> ReadAllDagSkabeloneAsync(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var dtos = await client.GetFromJsonAsync<List<DagSkabelonReadDto>>("api/DagSkabelon");
                var skabeloner = _mapper.Map<List<DagSkabelon>>(dtos);
                return skabeloner ?? new List<DagSkabelon>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af dagsskabeloner.");
                return new List<DagSkabelon>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af dagsskabeloner.");
                throw new Exception("Der opstod en uventet fejl under hentning af dagsskabeloner.", ex);
            }
        }

        public async Task<DagSkabelon> ReadDagSkabelonByIdAsync(int dagId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<DagSkabelonReadDto>($"api/DagSkabelon/{dagId}");
                return _mapper.Map<DagSkabelon>(dto) ?? new DagSkabelon();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af dagsskabelon med ID {Id}.", dagId);
                return new DagSkabelon();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af dagsskabelon.");
                throw new Exception("Der opstod en uventet fejl under hentning af dagsskabelonen.", ex);
            }
        }

        public async Task<bool> UpdateDagSkabelonAsync(int id, DagSkabelon dag, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<DagSkabelonUpdateDto>(dag);
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"api/DagSkabelon/{id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under opdatering af dagsskabelon med ID {Id}.", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved opdatering af dagsskabelon.");
                throw new Exception("Der opstod en uventet fejl under opdatering af dagsskabelonen.", ex);
            }
        }
    }
}
