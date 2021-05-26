using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class UserRepos : IUser
    {
        public IEnumerable<User> findAll()
        {
            var listUser = new List<User>();
            string connectionString = "Data Source=LAPTOP-7OO41Q78\\DCT;Initial Catalog=Project;Integrated Security=True";
            //khoi tao sql server
            SqlConnection sql = new SqlConnection(connectionString);
            Console.WriteLine(sql.State);
            // sqlcommand cho phep thao tac voi csdl
            SqlCommand sqlCommand = sql.CreateCommand();
            //khai bao cau truy van 
            sqlCommand.CommandText = "SELECT TOP (1000) [id],[Fullnname],[Username],[Password],[Adress] ,[Email] ,[Phone],[CreateDate] FROM[Project].[dbo].[User]";
            sql.Open();
            // mo ket noi voi database

            // thuc thi query
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // xu ly cai du lieu tra ve 
            while (sqlDataReader.Read())
            {
                User user = new User();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // lay ten cot du lieu dang doc 
                    var colName = sqlDataReader.GetName(i);
                    //lay gia tri cua cot dang doc
                    var value = sqlDataReader.GetValue(i);
                    //lay cai thuoc tinh cua User xem co cot nao giong voi cot hien tai
                    var property = user.GetType().GetProperty(colName);
                    if (property != null)
                    {
                        property.SetValue(user, value);
                    }


                }
                // them doi tuong vo danh sach
                listUser.Add(user);
            }
            return listUser;
        }
    }
}