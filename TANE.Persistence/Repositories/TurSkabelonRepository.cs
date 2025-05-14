using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using AutoMapper;
using TANE.Application.Dtos;
using TANE.Application.Dtos.Skabeloner;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;

namespace TANE.Persistence.Repositories
{
    public class TurSkabelonRepository : ITurSkabelonRepository
    {

        private readonly IHttpClientFactory _factory;
        private IMapper _mapper;
        public TurSkabelonRepository(IHttpClientFactory factory, IMapper mapper)
        {
            _factory = factory;
            _mapper = mapper;
        }

        private void SetJwtToken(HttpClient client, string jwtToken)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwtToken);
        }


        public async Task<bool> CreateTurSkabelon(TurSkabelon tur, string jwtToken)
        {
            //map
            var dto = _mapper.Map<TurSkabelonCreateDto>(tur);

            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("skabelon");

            // sæt dit Bearer-token
            SetJwtToken(client, jwtToken);
            // POST til baseAddress/“rejseplan”/tur
            var response = await client.PostAsJsonAsync("api/TurSkabelon", dto);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteTurSkabelon(int turId, string jwtToken)
        {
            // her henter du netop den HttpClient, du har konfigureret med AddHttpClient("rejseplan", ...)
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);
            // DELETE til baseAddress/“rejseplan”/tur
            var response = await client.DeleteAsync($"api/TurSkabelon/{turId}");
            return response.IsSuccessStatusCode;
        }


        public async Task<List<TurSkabelon>> ReadAllTurSkabeloner(string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            // Hent og deserialiser direkte til List<TurSkabelon>
            var dtos = await client.GetFromJsonAsync<List<TurSkabelonReadDto>>("api/TurSkabelon");

            //map
            var tours = _mapper.Map<List<TurSkabelon>>(dtos);

            // Hvis API’et returnerer 204 No Content, bliver tours null
            return tours ?? new List<TurSkabelon>();
        }

        public async Task<TurSkabelon> ReadTurSkabelonById(int turId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            // Problemet: du henter altid "…/rejseplan/tur" uden ID
            var dto = await client.GetFromJsonAsync<TurSkabelonReadDto>($"api/TurSkabelon/{turId}");

            //map
            var tur = _mapper.Map<TurSkabelon>(dto);

            return tur ?? new TurSkabelon();
        }


        public async Task<bool> UpdateTurSkabelon(int id, TurSkabelon tur, string jwtToken)
        {
            //map
            var dto = _mapper.Map<TurSkabelonUpdateDto>(tur);

            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            // PUT til https://.../rejseplan/tur/{id} med dto som JSON-body
            var response = await client.PutAsJsonAsync($"api/TurSkabelon/{id}", dto);

            // Returner true hvis status er 2xx
            return response.IsSuccessStatusCode;
        }

        public async Task AddDagToTurSkabelonAsync(int turId, int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsync(
                $"api/TurSkabelon/{turId}/dag/{dagId}",
                content: null
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task ReorderDageAsync(int turId, DagReorderDto dto, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.PostAsJsonAsync(
                $"api/TurSkabelon/{turId}/dage/reorder",
                dto
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveDagFromTurSkabelonAsync(int turId, int dagId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.DeleteAsync(
                $"api/TurSkabelon/{turId}/dag/{dagId}"
            );
            response.EnsureSuccessStatusCode();

        }

        public async Task<ObservableCollection<TurSkabelon>> ReadAllTurSkabelonePåRejseplan(int rejseplanId, string jwtToken)
        {
            var client = _factory.CreateClient("skabelon");
            SetJwtToken(client, jwtToken);

            var response = await client.GetAsync($"api/TurSkabelon/rejseplan/{rejseplanId}");

            response.EnsureSuccessStatusCode();
            var dtos = await response.Content.ReadFromJsonAsync<ObservableCollection<TurSkabelon>>();

            //mapping
            var tours = _mapper.Map<ObservableCollection<TurSkabelon>>(dtos);

            return tours ?? new ObservableCollection<TurSkabelon>();
        }
    }
}

