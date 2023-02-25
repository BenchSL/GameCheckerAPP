using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Models
{
    public class Account
    {
        public int id { get; set; }
        public UserModel AccountHolder { get; set; }

        public Account() { }
        public Account(UserModel AccountHolder)
        {
            this.AccountHolder = AccountHolder;
        }
    }
}
