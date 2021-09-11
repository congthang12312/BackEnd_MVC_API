using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CategoryRes : ICategory
    {
        public SqlConnection sqlCon = new DAO().connectDatabase();

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