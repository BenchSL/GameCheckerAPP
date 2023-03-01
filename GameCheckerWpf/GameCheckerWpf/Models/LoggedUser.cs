using GameCheckerWpf.LoginValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Models
{
    public class LoggedUser : BaseClass
    {
        private string username;
        private string email;

        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public LoggedUser()
        {
            if (UserSession.isValid)
            {
                this.UserName = UserSession.loggedUser.UserName;
                this.Email = UserSession.loggedUser.Email;
            }
        }
    }
}
