using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Web;

namespace API.Models
{
    public class CategoryRepo : ICategory
    {
        public SqlConnection sqlCon = new DAO().connectDatabase();
        public List<Product> findCategory(string category)
        {
            List<Product> listCategory = new List<Product>();
            SqlConnection connection = new DAO().connectDatabase();

            string sql = "select * from product where category=@category";

            SqlCommand command = null;
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.Add("@category", SqlDbType.VarChar).Value = category;


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
                    listCategory.Add(pro);
                }

                return listCategory;
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

        public List<Category> listCategory()
        {
            List<Category> proList = new List<Category>();
            sqlCon.Open();
            SqlCommand comd = sqlCon.CreateCommand();
            comd.CommandText = "select * from category";


            SqlDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {
                var pro = new Category();
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

        public List<Category> ListCategory()
        {
            var listCategory = new List<Category>();

            // sqlcommand cho phep thao tac voi csdl
            SqlCommand sqlCommand = sqlCon.CreateCommand();
            //khai bao cau truy van 
            sqlCommand.CommandText = " SELECT * FROM Category";
            sqlCon.Open();
            // mo ket noi voi database

            // thuc thi query
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            try
            {
                while (sqlDataReader.Read())
                {
                    Category category = new Category();
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        // lay ten cot du lieu dang doc 
                        var colName = sqlDataReader.GetName(i);
                        //lay gia tri cua cot dang doc
                        var value = sqlDataReader.GetValue(i);
                        //lay cai thuoc tinh cua User xem co cot nao giong voi cot hien tai
                        var property = category.GetType().GetProperty(colName);

                        if (property != null)
                        {
                            if (value == DBNull.Value)
                            {
                                property.SetValue(category, null);
                            }
                            else
                            {
                                property.SetValue(category, value);
                            }
                        }
                    }
                    // them doi tuong vo danh sach
                    listCategory.Add(category);
                }
            }
            catch (Exception e)
            {
                return listCategory;
                //  Block of code to handle errors
            }
            finally
            {
                if (sqlCon != null)
                {
                    sqlCon.Close();
                }
            }
            // xu ly cai du lieu tra ve 

            return listCategory;
        }

    }
}