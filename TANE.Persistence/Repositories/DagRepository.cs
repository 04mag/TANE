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

namespace TANE.Persistence.Repositories
{
    public class DagRepository : IDagRepository
    {

        private readonly IHttpClientFactory _factory;
        private IMapper _mapper;

        public DagRepository(IHttpClientFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateDagAsync(Dag dag, string jwtToken)
        {

            //map
            var dto = _mapper.Map<DagCreateDto>(dag);

            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // POST til baseAddress/“rejseplan”/dag
            var response = await client.PostAsJsonAsync("dag", dag);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteDagAsync(int dagId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            // DELETE til baseAddress/“rejseplan”/dag
            var response = await client.DeleteAsync($"dag/{dagId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<Dag>> ReadAllDageAsync(string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<Dag>
            var dtos = await client.GetFromJsonAsync<List<DagReadDto>>("dag");

            //map
            var dage = _mapper.Map<List<Dag>>(dtos);

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dage ?? new List<Dag>();
        }

        public async Task<Dag> ReadDagByIdAsync(int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<Dag>
            var dto = await client.GetFromJsonAsync<DagReadDto>($"dag/{dagId}");

            // map
            var dag = _mapper.Map<Dag>(dto);


            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dag ?? new Dag();

        }

        public async Task<bool> UpdateDagAsync(int id, Dag dag, string jwtToken)
        {
            //mapper
            var dto = _mapper.Map<DagUpdateDto>(dag);

            var client = _factory.CreateClient("rejseplan");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // PUT til https://.../rejseplan/dag/{id} med dto som JSON-body
            var response = await client.PutAsJsonAsync($"dag/{id}", dto);

            // Redagner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

      
    }
}
