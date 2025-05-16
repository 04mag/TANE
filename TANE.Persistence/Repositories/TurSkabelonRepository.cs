using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TANE.Application.Common.Exceptions;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class TurSkabelonRepository : ITurSkabelonRepository
    {
        private readonly IHttpClientFactory _factory;

        public TurSkabelonRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }

        public async Task<TurSkabelon> CreateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync("api/TurSkabelon", tur);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TurSkabelon>();

                    return result!;
                }
                else
                {
                    throw new Exception("Serveren returnerede en intern fejl. Prøv igen senere.");
                }
            }
            catch (Exception ex)
            {
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
            catch (Exception ex)
            { 
                throw new Exception("Der opstod en uventet fejl under sletningen af turskabelonen.", ex);
            }
        }

        public async Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var result = await client.GetFromJsonAsync<List<TurSkabelon>>("api/TurSkabelon");

                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under hentning af turskabelonerne.", ex);
            }
        }

        public async Task<TurSkabelon> ReadTurSkabelonById(int turId, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var result = await client.GetFromJsonAsync<TurSkabelon>($"api/TurSkabelon/{turId}");

                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under hentning af turskabelonerne.", ex);
            }
        }

        public async Task<TurSkabelon> UpdateTurSkabelon(int id, TurSkabelon tur, string jwtToken)
        {
            try
            {
                var client = _factory.CreateClient("skabelon");
                SetJwtToken(client, jwtToken);

                var response = await client.PutAsJsonAsync($"api/TurSkabelon/{id}", tur);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TurSkabelon>();
                    return result!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    throw new ConflictException("Der opstod en konflikt ved opdatering af turskabelonen.");
                }
                else
                {
                    throw new Exception("Serveren returnerede en intern fejl. Prøv igen senere.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Der opstod en uventet fejl under opdatering af turskabelonen.", ex);
            }
        }

        //Resten er ikke rettet til endnu og derfor udkommenteret
        //public async Task AddDagToTurSkabelonAsync(int turId, int dagId, string jwtToken)
        //{
        //    try
        //    {
        //        var client = _factory.CreateClient("skabelon");
        //        SetJwtToken(client, jwtToken);

        //        var response = await client.PostAsync($"api/TurSkabelon/{turId}/dag/{dagId}", null);
        //        if (!response.IsSuccessStatusCode)
        //            throw new Exception($"Kunne ikke tilføje dag til turskabelon: {response.StatusCode}.");
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        _logger.LogError(ex, "Fejl ved HTTP-opkald under tilføjelse af dag til turskabelon {TurId}.", turId);
        //        throw new Exception("Der opstod en HTTP-fejl under tilføjelse af dag til turskabelonen.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Uventet fejl ved tilføjelse af dag til turskabelon.");
        //        throw;
        //    }
        //}

        //public async Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken)
        //{
        //    try
        //    {
        //        var client = _factory.CreateClient("skabelon");
        //        SetJwtToken(client, jwtToken);

        //        var response = await client.PostAsJsonAsync($"api/TurSkabelon/{turId}/dage/reorder", dto);
        //        if (!response.IsSuccessStatusCode)
        //            throw new Exception($"Kunne ikke omrokere dage for turskabelon: {response.StatusCode}.");
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        _logger.LogError(ex, "Fejl ved HTTP-opkald under omrokering af dage for turskabelon {TurId}.", turId);
        //        throw new Exception("Der opstod en HTTP-fejl under omrokering af dage.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Uventet fejl ved omrokering af dage for turskabelon.");
        //        throw;
        //    }
        //}

        //public async Task RemoveDagFromTurSkabelonAsync(int turId, int dagId, string jwtToken)
        //{
        //    try
        //    {
        //        var client = _factory.CreateClient("skabelon");
        //        SetJwtToken(client, jwtToken);

        //        var response = await client.DeleteAsync($"api/TurSkabelon/{turId}/dag/{dagId}");
        //        if (!response.IsSuccessStatusCode)
        //            throw new Exception($"Kunne ikke fjerne dag fra turskabelon: {response.StatusCode}.");
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        _logger.LogError(ex, "Fejl ved HTTP-opkald under fjernelse af dag {DagId} fra turskabelon {TurId}.", dagId, turId);
        //        throw new Exception("Der opstod en HTTP-fejl under fjernelse af dag fra turskabelonen.", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Uventet fejl ved fjernelse af dag fra turskabelon.");
        //        throw;
        //    }
        //}

        //public async Task<ObservableCollection<TurSkabelon>> ReadAllTurSkabelonePåRejseplan(int rejseplanId, string jwtToken)
        //{
        //    try
        //    {
        //        var client = _factory.CreateClient("skabelon");
        //        SetJwtToken(client, jwtToken);

        //        var response = await client.GetAsync($"api/TurSkabelon/rejseplan/{rejseplanId}");
        //        if (!response.IsSuccessStatusCode)
        //            throw new Exception($"Kunne ikke hente turskabeloner på rejseplan: {response.StatusCode}.");

        //        var dtos = await response.Content.ReadFromJsonAsync<ObservableCollection<TurSkabelonReadDto>>();
        //        return _mapper.Map<ObservableCollection<TurSkabelon>>(dtos) ?? new ObservableCollection<TurSkabelon>();
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        _logger.LogError(ex, "Fejl ved HTTP-opkald under hentning af turskabeloner på rejseplan {PlanId}.", rejseplanId);
        //        return new ObservableCollection<TurSkabelon>();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Uventet fejl ved hentning af turskabeloner på rejseplan.");
        //        throw new Exception("Der opstod en uventet fejl under hentning af turskabeloner på rejseplanen.", ex);
        //    }
        //}
    }
}
