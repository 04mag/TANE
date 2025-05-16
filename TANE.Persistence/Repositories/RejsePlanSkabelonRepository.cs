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
    public class RejseplanSkabelonRepository : IRejseplanSkabelonRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<RejseplanSkabelonRepository> _logger;

        public RejseplanSkabelonRepository(
            IHttpClientFactory factory,
            IMapper mapper,
            ILogger<RejseplanSkabelonRepository> logger)
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

        public async Task<bool> CreateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<RejseplanSkabelonCreateDto>(rejseplanSkabelon);
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("api/RejseplanSkabelon", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under oprettelse af rejseplanskabelon.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved oprettelse af rejseplanskabelon.");
                throw new ArgumentException("Der opstod en uventet fejl under oprettelsen af rejseplanskabelonen.", ex);
            }
        }

        public async Task<bool> DeleteRejseplanSkabelonAsync(int id, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"api/RejseplanSkabelon/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under sletning af rejseplanskabelon med ID {Id}.", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved sletning af rejseplanskabelon.");
                throw new ArgumentException("Der opstod en uventet fejl under sletningen af rejseplanskabelonen.", ex);
            }
        }

        public async Task<List<RejseplanSkabelon>> ReadAllRejseplanSkabelonerAsync(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var dtos = await client.GetFromJsonAsync<List<RejseplanSkabelonReadDto>>("api/RejseplanSkabelon");
                var skabeloner = _mapper.Map<List<RejseplanSkabelon>>(dtos);
                return skabeloner ?? new List<RejseplanSkabelon>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af rejseplanskabeloner.");
                return new List<RejseplanSkabelon>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af rejseplanskabeloner.");
                throw new ArgumentException("Der opstod en uventet fejl under hentning af rejseplanskabelonerne.", ex);
            }
        }

        public async Task<RejseplanSkabelon> ReadRejseplanSkabelonByIdAsync(int id, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<RejseplanSkabelonReadDto>($"api/RejseplanSkabelon/{id}");
                return _mapper.Map<RejseplanSkabelon>(dto) ?? new RejseplanSkabelon();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af rejseplanskabelon med ID {Id}.", id);
                return new RejseplanSkabelon();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af rejseplanskabelon.");
                throw new ArgumentException("Der opstod en uventet fejl under hentning af rejseplanskabelonen.", ex);
            }
        }

        public async Task<bool> UpdateRejseplanSkabelonAsync(RejseplanSkabelon rejseplanSkabelon, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<RejseplanSkabelonUpdateDto>(rejseplanSkabelon);
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"api/RejseplanSkabelon/{rejseplanSkabelon.Id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under opdatering af rejseplanskabelon med ID {Id}.", rejseplanSkabelon.Id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved opdatering af rejseplanskabelon.");
                throw new ArgumentException("Der opstod en uventet fejl under opdatering af rejseplanskabelonen.", ex);
            }
        }
    }
}
