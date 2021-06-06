using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProductRepo : IProduct
    {
        public static SqlConnection connectDatabase()
        {
            string connectionString = "Data Source=ADMIN-PC;Initial Catalog=phonedb;Integrated Security=True";
            //khoi tao sql server
            return new SqlConnection(connectionString);
        }

  

        public List<Product> listProduct()
        {

            List<Product> proList = new List<Product>();



            SqlConnection sqlCon = connectDatabase();

            SqlCommand comd = sqlCon.CreateCommand();
            comd.CommandText = "select * from product";

            sqlCon.Open();

            SqlDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {
                var pro = new Product();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var colName = reader.GetName(i);
                    var value = reader.GetValue(i);

                    var prop = pro.GetType().GetProperty(colName);


                    if (prop != null && value != DBNull.Value)
                    {
                        prop.SetValue(pro, value);
                    }

                }
                proList.Add(pro);
            }


            return proList;
        }
        public Product findProduct(int id)
        {
            Product p = null;
            List<Product> list = listProduct();
            foreach (Product item in list)
            {
                if (item.id == id)
                {
                    p = item;
                }
            }
            return p;
        }

    }
}
