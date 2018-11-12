using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
   public class MemoryItem
    {
        public int Memory_ID { get; set; }
        public DateTime date { get; set; }

        public String title { get; set; }

        public String Description { get; set; }

        public int User_ID { get; set; }
    }
}
