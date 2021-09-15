using DatabaseAccess;
using SlugGenerator;
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

        public List<Product> listProductByPage(int page)
        {
            List<Product> proList = new List<Product>();
            sqlCon.Open();
            SqlCommand comd = sqlCon.CreateCommand();
            comd.CommandText = " select ok.id,ok.name,ok.slug,ok.thumbnail,ok.price,ok.category,ok.sub_category,ok.quantity,ok.description,ok.createAt,ok.modifyAt  from (select ROW_NUMBER() over (order by id) as row, * from  Product ) as ok " +
                               " where ok.row between(@page-1)*10+1 and (@page-1)*10+10";
            comd.Parameters.Add("@page", SqlDbType.Int).Value = page;
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

        public bool updateProduct(Product product)
        {
            string sql = "update Product set id = @id, name = @name , slug = @slug, thumbnail = @thumbnail, price = @price ,category = @category , sub_category = null , quantity =@quantity , description = @description , createAt = @createAt , modifyAt = default " +
                        "where id = @id ";
            if (product != null)
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand comd = sqlCon.CreateCommand();
                    comd.CommandText = sql;
                    product.slug = product.name.GenerateSlug();
                    product.sub_category = "5b3b02a4-b676-4255-a816-5c4362333e01";
                    comd.Parameters.Add("@id", SqlDbType.VarChar).Value = product.id;
                    comd.Parameters.Add("@name", SqlDbType.NVarChar).Value = product.name;
                    comd.Parameters.Add("@slug", SqlDbType.NVarChar).Value = product.slug;
                    comd.Parameters.Add("@thumbnail", SqlDbType.VarChar).Value = product.thumbnail;
                    comd.Parameters.Add("@price", SqlDbType.Float).Value = Convert.ToDouble(product.price);
                    comd.Parameters.Add("@category", SqlDbType.VarChar).Value = product.category;
                    comd.Parameters.Add("@sub_category", SqlDbType.VarChar).Value = product.sub_category;
                    comd.Parameters.Add("@quantity", SqlDbType.Int).Value = product.quantity;
                    comd.Parameters.Add("@description", SqlDbType.NVarChar).Value = product.description;
                    comd.Parameters.Add("@createAt", SqlDbType.DateTime).Value = product.createAt;
                    comd.Parameters.Add("@modifyAt", SqlDbType.DateTime).Value = DateTime.Now;
                    int r = comd.ExecuteNonQuery();
                    if (r != -1)
                        return true;
                    return false;
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
            else
            {
                return false;
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

        public Boolean addProduct(Product product)
        {
            Guid myuuid = Guid.NewGuid();
            product.id = myuuid.ToString();
            product.slug = product.name.GenerateSlug();
            product.sub_category = "5b3b02a4-b676-4255-a816-5c4362333e01";
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
                    command.Parameters.Add("@price", SqlDbType.Float).Value = Convert.ToDouble(product.price);
                    command.Parameters.Add("@category", SqlDbType.VarChar).Value = product.category;
                    command.Parameters.Add("@sub_category", SqlDbType.VarChar).Value = product.sub_category;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = product.quantity;
                    command.Parameters.Add("@description", SqlDbType.NVarChar).Value = product.description;
                    command.Parameters.Add("@createAt", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@modifyAt", SqlDbType.DateTime).Value = DateTime.Now;
                    int r = command.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
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

        public Boolean addHistory(History_Buy history)
        {
            string sql = "INSERT INTO [History_Buy] (idUser,idProduct,quantity,address,createAt,modifyAt)" +
                   "VALUES(@idUser,@idProduct ,@quantity ,@address,@createAt ,@modifyAt )";
            SqlCommand command = null;
            try
            {
                sqlCon.Open();
                command = sqlCon.CreateCommand();
                command.CommandText = sql;

                if (history != null)
                {
                    command.Parameters.Add("@idUser", SqlDbType.VarChar).Value = history.idUser;
                    command.Parameters.Add("@idProduct", SqlDbType.NVarChar).Value = history.idProduct;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = history.quantity;
                    command.Parameters.Add("@address", SqlDbType.NVarChar).Value = history.address;
                    command.Parameters.Add("@createAt", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@modifyAt", SqlDbType.DateTime).Value = DateTime.Now;
                    int r = command.ExecuteNonQuery();
                    if (r != -1)
                        return true;
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
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
