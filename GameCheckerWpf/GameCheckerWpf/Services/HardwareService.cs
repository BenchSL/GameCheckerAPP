using GameCheckerWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Services
{
    public class HardwareService
    {
        private readonly HttpClient client;

        public HardwareService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ComputerHardware> addGame(GameModel gameM)
        {
            var response = await client.PostAsJsonAsync("http://localhost:31686/api/Game", gameM);
            return await response.Content.ReadFromJsonAsync<GameModel>();
        }
    }
}
