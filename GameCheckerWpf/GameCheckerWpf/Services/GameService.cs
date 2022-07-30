using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GameCheckerWpf.Models;

namespace GameCheckerWpf.Services
{
    public class GameService
    {
        private readonly HttpClient client;

        public GameService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<GameModel>> getGames()
        {
            return await client.GetFromJsonAsync<List<GameModel>>("http://localhost:31686/api/Game");
        }

        public async Task<GameModel> addGame(GameModel gameM)
        {
            var response = await client.PostAsJsonAsync("http://localhost:31686/api/Game", gameM);
            return await response.Content.ReadFromJsonAsync<GameModel>();
        }

        public async Task<GameModel> getGame(int id)
        {
            return await client.GetFromJsonAsync<GameModel>($"http://localhost:31686/api/Game/{id}");
        }

        public async Task<GameModel> updateGameModel(GameModel gModel)
        {
            var response = await client.PutAsJsonAsync<GameModel>("http://localhost:31686/api/Game", gModel);
            return await response.Content.ReadFromJsonAsync<GameModel>();
        }

        public async Task deleteGameModel(int id)
        {
            var response = await client.DeleteAsync($"http://localhost:31686/api/Game/{id}");
        }
    }
}
