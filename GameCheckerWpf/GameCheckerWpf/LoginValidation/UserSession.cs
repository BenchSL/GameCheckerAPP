using GameCheckerWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.LoginValidation
{
    public static class UserSession
    {
        public static bool isValid { get; set; }
        public static UserModel loggedUser { get; set; }
    }
}
