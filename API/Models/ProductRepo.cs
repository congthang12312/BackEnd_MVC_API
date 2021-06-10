using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProductRepo : IProduct
    {

        public SqlConnection sqlCon = new DAO().connectDatabase();

        public List<Product> listProduct()
        {

            List<Product> proList = new List<Product>();

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

        public Boolean addProduct(Product product)
        {
            string sql = "INSERT INTO[Product] (id,name,slug,thumbnail,price,category,sub_category,quantity,description,createAt,modifyAt)" +
                "VALUES(@id,@name,@slug,@thumbnail,@price,@category,@sub_category,@quantity,@description,@createAt,@modifyAt)";
            SqlCommand command = null;
            try
            {
                sqlCon.Open();
                command = sqlCon.CreateCommand();
                command.CommandText = sql;
                if (product != null)
                {
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = product.id;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.name;
                    command.Parameters.Add("@slug", SqlDbType.NVarChar).Value = product.slug;
                    command.Parameters.Add("@thumbnail", SqlDbType.VarChar).Value = product.thumbnail;
                    command.Parameters.Add("@price", SqlDbType.Int).Value = product.price;
                    command.Parameters.Add("@category", SqlDbType.VarChar).Value = product.category;
                    command.Parameters.Add("@sub_category", SqlDbType.VarChar).Value = product.sub_category;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = product.quantity;
                    command.Parameters.Add("@description", SqlDbType.VarChar).Value = product.description;
                    command.Parameters.Add("@createAt", SqlDbType.DateTime).Value = product.createAt;
                    command.Parameters.Add("@modifyAt", SqlDbType.DateTime).Value = product.modifyAt;
                    // thuc thi cau lenh cho (them xoa sua)
                    int r = command.ExecuteNonQuery();
                  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E)
            {
                
                return false;
            }
            finally
            {
                if (sqlCon != null)
                {
                    sqlCon.Close();
                }
            }
        }

        public bool deleteProduct(string id)
        {
            string sql = "DELETE FROM [Product] WHERE id = @id ";
            SqlCommand command = null;
            try
            {
                sqlCon.Open();
                command = sqlCon.CreateCommand();
                command.CommandText = sql;
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
                if (sqlCon != null)
                {
                    sqlCon.Close();
                }
            }
        }
    }
}
