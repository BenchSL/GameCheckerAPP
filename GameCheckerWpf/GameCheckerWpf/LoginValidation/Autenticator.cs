using GameCheckerAPI.AutenticationServices;
using GameCheckerWpf.Exceptions;
using GameCheckerWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.LoginValidation
{
    public class Autenticator : IAutenticator
    {
        private readonly HttpClient client;

        public Autenticator(HttpClient client)
        {
            this.client = client;
        }

        public Account currentAccount { get; private set; }

        public bool isLoggedIn => currentAccount != null;

        public async Task<bool> Login(string username, string password)
        {
            bool success = await client.GetFromJsonAsync<bool>($"http://localhost:31686/api/Autentication/{username}/{password}");

            if (success)
            {
                UserModel userModel = new UserModel(username, password);
                UserSession.isValid = true;
                UserSession.loggedUser = userModel;
            }

            return success;
            //bool success = await autenticationService.Login(username, password);
            //UserModel userModel = new UserModel(username, password);
            //if (success)
            //{
            //    Account loggedAcc = new Account(userModel);
            //    currentAccount = loggedAcc;
            //}
            //return success;
        }

        public void Logout()
        {
            currentAccount = null;
        }

        public async Task<bool> Register(string email, string username, string password, string confirmPassword)
        {
            bool success = await client.GetFromJsonAsync<bool>($"http://localhost:31686/api/Autentication/{username}/{password}/{email}/{confirmPassword}");
            return success;
            //return await autenticationService.Register(username, password, email, confirmPassword);
        }
    }
}
