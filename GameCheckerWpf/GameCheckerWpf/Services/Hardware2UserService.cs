using GameCheckerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Services
{
    public class Hardware2UserService
    {
        private readonly HttpClient client;

        public Hardware2UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Hardware2User> addHardware2User(int computerHardwareId, int userId)
        {
            return await client.GetFromJsonAsync<Hardware2User>($"http://localhost:31686/api/Hardware2User/{computerHardwareId}/{userId}");
        }
    }
}
