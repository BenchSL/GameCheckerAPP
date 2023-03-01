using GameCheckerWpf.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Services
{
    public class UserService
    {
        private readonly HttpClient client;

        public UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<UserModel> loginUser(string Username, string Password)
        {
            return await client.GetFromJsonAsync<UserModel>($"http://localhost:31686/api/User/{Username}/{Password}");
        }

        public async Task<UserModel> registerUser(string userName, string password, string email)
        {
            return await client.GetFromJsonAsync<UserModel>($"http://localhost:31686/api/User/{userName}/{password}/{email}");
        }

        public async Task<IEnumerable<UserModel>> getUsers()
        {
            return await client.GetFromJsonAsync<List<UserModel>>("http://localhost:31686/api/User");
        }

        public async Task<UserModel> addUser(UserModel userM)
        {
            var response = await client.PostAsJsonAsync("http://localhost:31686/api/User", userM);
            return await response.Content.ReadFromJsonAsync<UserModel>();
        }

        public async Task<UserModel> getUser(int id)
        {
            return await client.GetFromJsonAsync<UserModel>($"http://localhost:31686/api/User/{id}");
        }

        public async Task<UserModel> updateUser(UserModel userM)
        {
            var response = await client.PutAsJsonAsync<UserModel>("http://localhost:31686/api/User", userM);
            return await response.Content.ReadFromJsonAsync<UserModel>();
        }

        public async Task deleteUser(int id)
        {
            var response = await client.DeleteAsync($"http://localhost:31686/api/User/{id}");
        }
    }
}
