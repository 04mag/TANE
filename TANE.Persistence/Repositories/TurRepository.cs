    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
        public class TurRepository : ITurRepository
        {

            private readonly IHttpClientFactory _factory;
            private Mapper _mapper;

            public TurRepository(IHttpClientFactory factory, Mapper mapper)
            {
                _factory = factory;
                _mapper = mapper;
            }

            private void SetJwtToken(HttpClient client, string jwtToken)
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", jwtToken);
            }


            public async Task<bool> CreateTur(Tur tur, string jwtToken)
            {
            //map 
            var dto = _mapper.Map<TurCreateDto>(tur);

            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("rejseplan");

                // sæt dit Bearer-token
                SetJwtToken(client, jwtToken);
                // POST til baseAddress/“rejseplan”/tur
                var response = await client.PostAsJsonAsync("tur", dto);
                return response.IsSuccessStatusCode;
            }


            public async Task<bool> DeleteTur(int turId, string jwtToken)
            {
                // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);
                // DELETE til baseAddress/“rejseplan”/tur
                var response = await client.DeleteAsync($"tur/{turId}");
                return response.IsSuccessStatusCode;
            }


            public async Task<List<Tur>> ReadAllTure(string jwtToken)
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                // Hent og deserialiser direkte til List<Tur>
                var dtos = await client.GetFromJsonAsync<List<TurReadDto>>("Tur");

            //map
            var tours = _mapper.Map<List<Tur>>(dtos);

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<Tur>();
            }

            public async Task<Tur> ReadTurById(int turId, string jwtToken)
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var dto = await client.GetFromJsonAsync<TurReadDto>($"Tur/{turId}");

            //map
            var tur = _mapper.Map<Tur>(dto);

            // Hvis API’et returnerer 204 No Content, bliver tur null

            return tur ?? new Tur();
            }


            public async Task<bool> UpdateTur(int id, Tur tur, string jwtToken)
            {

            //map
            var dto = _mapper.Map<TurUpdateDto>(tur);

            var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                // PUT til https://.../rejseplan/tur/{id} med dto som JSON-body
                var response = await client.PutAsJsonAsync($"tur/{id}", dto);

                // Returner true hvis status er 2xx
                return response.IsSuccessStatusCode;
            }

            public async Task AddDagToTurAsync(int turId, int dagId, string jwtToken)
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsync(
                    $"tur/{turId}/dag/{dagId}",
                    content: null
                );
                response.EnsureSuccessStatusCode();
            }

            public async Task ReorderDageAsync(int turId, Dag tur, string jwtToken)
            {

            //map
            var dto = _mapper.Map<DagReorderDto>(tur);

            var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.PostAsJsonAsync(
                    $"tur/{turId}/dage/reorder", dto);
                response.EnsureSuccessStatusCode();
            }

            public async Task RemoveDagFromTurAsync(int turId, int dagId, string jwtToken)
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.DeleteAsync(
                    $"tur/{turId}/dag/{dagId}"
                );
                response.EnsureSuccessStatusCode();

            }

            public async Task<ObservableCollection<Tur>> ReadAllTurePåRejseplan(int rejseplanId, string jwtToken)
            {
                var client = _factory.CreateClient("rejseplan");
                SetJwtToken(client, jwtToken);

                var response = await client.GetAsync($"tur/rejseplan/{rejseplanId}");
                response.EnsureSuccessStatusCode();
                var dtos = await response.Content.ReadFromJsonAsync<ObservableCollection<TurReadDto>>();

            //map
            var tours = _mapper.Map<ObservableCollection<Tur>>(dtos);

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new ObservableCollection<Tur>();
            }
        }
    }
