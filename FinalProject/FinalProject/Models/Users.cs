using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    public class Users
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string Id { get; set; }
        






        public Users()
        {

        }

        public Users(String Username, String Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public Users(String FirstName, String LastName, String Username, String Email, String Password, String Id)
        {


            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
           




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
