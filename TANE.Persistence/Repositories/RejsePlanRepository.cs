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
using TANE.Application.Dtos.TurDagRejseplan;

namespace TANE.Persistence.Repositories
{
    public class RejseplanRepository : IRejseplanRepository
    {
        private readonly IHttpClientFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<RejseplanRepository> _logger;

        public RejseplanRepository(
            IHttpClientFactory factory,
            IMapper mapper,
            ILogger<RejseplanRepository> logger)
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

        public async Task<bool> CreateRejseplan(Rejseplan rejseplan, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<RejseplanCreateDto>(rejseplan);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("rejseplan", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under oprettelse af rejseplan.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved oprettelse af rejseplan.");
                throw new Exception("Der opstod en uventet fejl under oprettelsen af rejseplanen.", ex);
            }
        }

        public async Task<bool> DeleteRejseplan(int rejseplanId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"rejseplan/{rejseplanId}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under sletning af rejseplan med ID {Id}.", rejseplanId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved sletning af rejseplan.");
                throw new Exception("Der opstod en uventet fejl under sletningen af rejseplanen.", ex);
            }
        }

        public async Task<List<Rejseplan>> ReadAllRejseplaner(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dtos = await client.GetFromJsonAsync<List<RejseplanReadDto>>("rejseplan");
                var items = _mapper.Map<List<Rejseplan>>(dtos);

                return items ?? new List<Rejseplan>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af alle rejseplaner.");
                return new List<Rejseplan>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af rejseplaner.");
                throw new Exception("Der opstod en uventet fejl under hentning af rejseplanerne.", ex);
            }
        }

        public async Task<Rejseplan> ReadRejseplanById(int rejseplanId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<RejseplanReadDto>($"rejseplan/{rejseplanId}");
                return _mapper.Map<Rejseplan>(dto) ?? new Rejseplan();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af rejseplan med ID {Id}.", rejseplanId);
                return new Rejseplan();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved hentning af rejseplan.");
                throw new Exception("Der opstod en uventet fejl under hentning af rejseplanen.", ex);
            }
        }

        public async Task<bool> UpdateRejseplan(int id, Rejseplan rejseplan, string jwtToken)
        {
            try
            {
                var dto = _mapper.Map<RejseplanUpdateDto>(rejseplan);
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"rejseplan/{id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under opdatering af rejseplan med ID {Id}.", id);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved opdatering af rejseplan.");
                throw new Exception("Der opstod en uventet fejl under opdatering af rejseplanen.", ex);
            }
        }

        public async Task ReorderTureAsync(int rejseplanId, TurReorderDto newOrder, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync($"rejseplan/{rejseplanId}/ture/reorder", newOrder);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Kunne ikke ændre rækkefølgen af ture: {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under omrokering af ture for rejseplan ID {Id}.", rejseplanId);
                throw new Exception("Der opstod en HTTP-fejl under omrokering af ture.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved omrokering af ture.");
                throw new Exception("Der opstod en uventet fejl under omrokering af ture.", ex);
            }
        }

        public async Task AddTurToRejseplanAsync(TurAssignDto assignDto, string jwtToken)
        {
            try
            {
                
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync($"rejseplan/{assignDto.RejseplanId}/tur/{assignDto.TurId}", assignDto);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Kunne ikke tilføje tur til rejseplan: {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under tilføjelse af tur til rejseplan ID {Id}.", assignDto.RejseplanId);
                throw new Exception("Der opstod en HTTP-fejl under tilføjelse af tur.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved tilføjelse af tur til rejseplan.");
                throw new Exception("Der opstod en uventet fejl under tilføjelse af tur til rejseplan.", ex);
            }
        }

        public async Task RemoveTurFromRejseplanAsync(int rejseplanId, int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync($"rejseplan/{rejseplanId}/tur/{turId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Kunne ikke fjerne tur fra rejseplan: {response.StatusCode}.");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Fejl ved HTTP-opkald under fjernelse af tur {TurId} fra rejseplan {PlanId}.", turId, rejseplanId);
                throw new Exception("Der opstod en HTTP-fejl under fjernelse af tur fra rejseplan.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Uventet fejl ved fjernelse af tur fra rejseplan.");
                throw new Exception("Der opstod en uventet fejl under fjernelse af tur fra rejseplan.", ex);
            }
        }
    }
}
