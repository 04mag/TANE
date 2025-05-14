using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using TANE.Application.RepositoryInterfaces;
using TANE.Application.Dtos.Skabeloner;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class DagSkabelonRepository : IDagSkabelonRepository
    {

        private readonly IHttpClientFactory _factory;
        private IMapper _mapper;

        public DagSkabelonRepository(IHttpClientFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateDagSkabelonAsync(DagSkabelon dag, string jwtToken)
        {
            //map
            var dto = _mapper.Map<DagSkabelonCreateDto>(dag);

            var client = _factory.CreateClient("skabelon");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        
            var response = await client.PostAsJsonAsync("api/DagSkabelon", dag);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteDagSkabelonAsync(int dagId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("skabelon", ...)
            var client = _factory.CreateClient("skabelon");

            // sæt dit Bearer-token
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        
            var response = await client.DeleteAsync($"api/DagSkabelon/{dagId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<DagSkabelon>> ReadAllDagSkabeloneAsync(string jwtToken)
        {
            //map

            var client = _factory.CreateClient("skabelon");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<DagSkabelon>
            var dtos = await client.GetFromJsonAsync<List<DagSkabelonReadDto>>("api/DagSkabelon");

            //map
            var dage = _mapper.Map<List<DagSkabelon>>(dtos);

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dage ?? new List<DagSkabelon>();
        }

        public async Task<DagSkabelon> ReadDagSkabelonByIdAsync(int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);

            // Hent og deserialiser direkte til List<DagSkabelon>
            var dto = await client.GetFromJsonAsync<DagSkabelonReadDto>($"api/DagSkabelon/{dagId}");

            //map
            var dag = _mapper.Map<DagSkabelon>(dto);


            // Hvis API’et returnerer 204 No Content, bliver tours null
            return dag ?? new DagSkabelon();

        }

        public async Task<bool> UpdateDagSkabelonAsync(int id, DagSkabelon dag, string jwtToken)
        {
            //map
            var dto = _mapper.Map<DagSkabelonUpdateDto>(dag);

            var client = _factory.CreateClient("skabelon");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
            
            var response = await client.PutAsJsonAsync($"api/DagSkabelon/{id}", dto);

            // Redagner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }


    }
}
