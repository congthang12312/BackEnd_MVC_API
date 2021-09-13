using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class DAO
    {
        public SqlConnection connectDatabase()
        {
           // string connectionString ="Data Source = DESKTOP-CK5OO7H; Initial Catalog = Probject; Integrated Security = True";
            string connectionString = "Data Source = LAPTOP-7OO41Q78\\DCT; Initial Catalog = Project; Integrated Security = True";
            //khoi tao sql server
            return new SqlConnection(connectionString);
        }
    }
}