using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProductRepos : IProduct
    {
        public SqlConnection sqlCon = new DAO().connectDatabase();

        public List<Product> listProduct()
        {

            List<Product> proList = new List<Product>();
            sqlCon.Open();
            SqlCommand comd = sqlCon.CreateCommand();
            comd.CommandText = "select * from product";


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
            sqlCon.Close();
            return proList;
        }
        public Product findProduct(string id)
        {
            Product p = null;
            List<Product> list = listProduct();
            foreach (Product item in list)
            {
                if (item.id.Equals(id))
                {
                    p = item;
                }
            }
            return p;
        }
        //cap nhat so luong sau khi nguoi dung mua hang
        public Boolean updateProduct(string id, int amount)
        {
            SqlConnection connection = new DAO().connectDatabase();
            string sql = "UPDATE [dbo].[PRODUCT] SET quantity=quantity-@amount  WHERE id = @id ";
            SqlCommand command = null;
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                int r = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<Product> listProductInPage(int page, int productAmount)
        {
            int totalProduct = listProduct().Count;

            List<Product> proList = new List<Product>();

            SqlConnection connection = new DAO().connectDatabase();



            string sql = "SELECT * FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY quantity) as row FROM [dbo].[PRODUCT]) a WHERE a.row >= (@page-1)*@productAmount+1 and a.row <= @page*@productAmount";

            SqlCommand command = null;


            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;
                if (page <= totalProduct / productAmount + totalProduct % productAmount)
                {
                    command.Parameters.Add("@page", SqlDbType.Int).Value = page;
                }
                else
                {
                    command.Parameters.Add("@page", SqlDbType.Int).Value = 1;
                }


                command.Parameters.Add("@productAmount", SqlDbType.Int).Value = productAmount;


                SqlDataReader reader = command.ExecuteReader();
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
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }



        }

      
    }
}
