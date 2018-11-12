using SQLite;
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

        public int User_ID  {get; set;}
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
