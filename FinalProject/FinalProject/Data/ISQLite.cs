using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data
{
   public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
