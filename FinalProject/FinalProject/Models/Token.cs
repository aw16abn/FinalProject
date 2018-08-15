using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    class Token
    {
        public int Id { get; set; }
        public string Access_Token { get; set; }
        public string Error_description { get; set; }
        public DateTime Expire_date { get; set; }

        public Token() { }

    }
}
