﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
     public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User ()
        {

        }

        public User (String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public bool CheckInformation()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
