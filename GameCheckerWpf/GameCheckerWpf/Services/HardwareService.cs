
using GameCheckerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        public async Task<ComputerHardware> addHardware(string cpu, string ram, string os, string graphicsCard, string guid)
        {
            return await client.GetFromJsonAsync<ComputerHardware>($"http://localhost:31686/api/ComputerHardware/{cpu}/{ram}/{os}/{graphicsCard}/{guid}");
        }

        public async Task<ComputerHardware> getHardware(int id)
        {
            return await client.GetFromJsonAsync<ComputerHardware>($"http://localhost:31686/api/ComputerHardware/{id}");
        }
    }
}
