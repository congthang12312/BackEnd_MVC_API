using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class DAO
    {
        public  SqlConnection connectDatabase()
        {
            string connectionString = "Data Source=ADMIN-PC;Initial Catalog=Project;Integrated Security=True";
            //khoi tao sql server
            return new SqlConnection(connectionString);
        }
    }
}