﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public String Id { get; set; }

        



      
        public User ()
        {

        }

        public User (String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public User (String FirstName, String LastName, String Username, String Email, String Password, String Id)
        {

         
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Id = Id;
            
            
            

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
