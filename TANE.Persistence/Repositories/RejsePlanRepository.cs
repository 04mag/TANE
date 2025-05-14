using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Application.Dtos;
using TANE.Application.Dtos.TurDagRejseplan;

namespace TANE.Persistence.Repositories
{
    public class RejsePlanRepository : IRejsePlanRepository
    {
        private readonly IHttpClientFactory _factory;
        private Mapper _mapper;

        public RejsePlanRepository(IHttpClientFactory factory, Mapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateRejseplan(Rejseplan rejseplan, string jwtToken)
        {
            //Map rejserplan til create dto
            var rejseplanCreateDto = _mapper.Map<RejseplanCreateDto>(rejseplan);


            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // POST til baseAddress/“rejseplan”/rejseplan
            var response = await client.PostAsJsonAsync("rejseplan", rejseplanCreateDto);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteRejseplan(int rejseplanId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // DELETE til baseAddress/“rejseplan”/rejseplan
            var response = await client.DeleteAsync($"rejseplan/{rejseplanId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<Rejseplan>> ReadAllRejseplaner(string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<RejseplanReadDto>
            var dtos = await client.GetFromJsonAsync<List<RejseplanReadDto>>("rejseplan");

            //map
            var tours = _mapper.Map<List<Rejseplan>>(dtos);

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<Rejseplan>();
        }

        public async Task<Rejseplan> ReadRejseplanById(int rejseplanId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Problemet: du henter altid "…/rejseplan/rejseplan" uden ID
            var dto = await client.GetFromJsonAsync<RejseplanReadDto>($"rejseplan/{rejseplanId}");

            //map
            var rejseplan = _mapper.Map<Rejseplan>(dto);

            return rejseplan ?? new Rejseplan();
        }

        public async Task<bool> UpdateRejseplan(int id, Rejseplan rejseplan, string jwtToken)
        {
            //Map rejseplan til update dto
            var rejseplanUpdateDto = _mapper.Map<RejseplanUpdateDto>(rejseplan);

            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.PutAsJsonAsync($"rejseplan/{id}", rejseplanUpdateDto);

            // Returner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

        public async Task ReorderTureAsync(int rejseplanId, Tur tur, string jwtToken)
        {

            //Map tur til reorder dto
            var dto = _mapper.Map<TurReorderDto>(tur);

            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.PostAsJsonAsync($"rejseplan/{rejseplanId}/ture/reorder", dto);

            // Returner true hvis status er 2xx
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to reorder tours: {response.StatusCode}");
            }
            // Hvis API’et returnerer 204 No Content, bliver tours null


            // Optional: håndter svaret, hvis nødvendigt
            //var result = await response.Content.ReadFromJsonAsync<bool>();
            //if (!result)
            //{
            //    throw new Exception("Reordering tours failed.");
            //}
        }

        public async Task AddTurToRejseplanAsync(Tur tur, string jwtToken)
        {
            //Map tur til assign dto
            var dto = _mapper.Map<TurAssignDto>(tur);
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.PostAsJsonAsync($"rejseplan/{dto.RejseplanId}/tur/{dto.TurId}", dto);

            // Returner true hvis status er 2xx
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add tour to rejseplan: {response.StatusCode}");
            }
        }

        public async Task RemoveTurFromRejseplanAsync( int rejseplanId, int turId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await client.DeleteAsync($"rejseplan/{rejseplanId}/tur/{turId}");

            // Returner true hvis status er 2xx
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to remove tour from rejseplan: {response.StatusCode}");
            }
        }
    }
}