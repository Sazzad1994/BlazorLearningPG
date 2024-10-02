using CRUDProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProject.Shared.Services
{
    public class ClientGameService : IGameService
    { 
        private readonly HttpClient _httpClient;

        public ClientGameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Game> AddGames(Game game1)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/game", game1);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<bool> DeleteGames(int Id)
        {
            var result = await _httpClient.DeleteAsync($"/api/game/{Id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async  Task<Game> EditGames(int Id, Game game1)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/game/{Id}", game1);
            return await result.Content.ReadFromJsonAsync<Game>();
        }

        public async Task<List<Game>> GetAllGames()
        {
            throw new NotImplementedException();
      
        }

        public async Task<Game> GetGameById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Game>($"/api/game/{(int)Id}");
            return result;
        }
    }
}
