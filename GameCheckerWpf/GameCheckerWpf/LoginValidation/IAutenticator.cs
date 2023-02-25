using GameCheckerWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.LoginValidation
{
    public interface IAutenticator
    {
        Account currentAccount { get; }
        bool isLoggedIn { get; }

        Task<bool> Register(string email, string username, string password, string confirmPassword);
        Task<bool> Login(string username, string password);
        void Logout();
    }
}
