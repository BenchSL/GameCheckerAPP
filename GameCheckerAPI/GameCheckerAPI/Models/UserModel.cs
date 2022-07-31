﻿using System.ComponentModel.DataAnnotations;

namespace GameCheckerAPI.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel() { }

        public UserModel(string name, string pass)
        {
            this.Username = name;
            this.Password = pass;
        }
    }
}