﻿using System.ComponentModel.DataAnnotations;

namespace GameCheckerAPI.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        public UserModel AccountHolder { get; set; }

        public Account() { }
        public Account(UserModel AccountHolder)
        {
            this.AccountHolder = AccountHolder;
        }
    }
}
