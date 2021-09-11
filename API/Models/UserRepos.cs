using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using DatabaseAccess;
namespace API.Models
{
    public class UserRepos : IUser
    {
        public static SqlConnection connectDatabase()
        {
            string connectionString = "Data Source=ABS\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            //khoi tao sql server
            return new SqlConnection(connectionString);
        }

        public List<User> findAll()
        {
            var listUser = new List<User>();
            SqlConnection sql = connectDatabase();
            // sqlcommand cho phep thao tac voi csdl
            SqlCommand sqlCommand = sql.CreateCommand();
            //khai bao cau truy van 
            sqlCommand.CommandText = "SELECT TOP (1000) [id],[fullname],[email],[password],[googleID] ,[facebookID] ,[role],[createAt],[modifyAt] FROM[Project].[dbo].[User]";
            sql.Open();
            // mo ket noi voi database

            // thuc thi query
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            try
            {
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
                            if (value == DBNull.Value)
                            {
                                property.SetValue(user, null);
                            }
                            else {
                                property.SetValue(user, value);
                            }
                        }
                    }
                    // them doi tuong vo danh sach
                    listUser.Add(user);
                }
            }
            catch (Exception e)
            {
                return listUser;
                //  Block of code to handle errors
            }
            // xu ly cai du lieu tra ve 
           
            return listUser;
        }

       

        public User findIdUser(String id)
        {
            User user = null;
           // List<User> list = findAll();
          //  foreach(User index in list)
          //  {
            //    if(index.C_id == id)
         //       {
              //      user = index;
            //    }
           // }
            return user;

        }
        public Boolean insertUser(User user)
        {
            SqlConnection connection = connectDatabase();
            string sql = "INSERT INTO [dbo].[User](id,Fullnname,Username,Password,Adress,Email,Phone,CreateDate)" +
                " VALUES(@id,@Fullnname,@Username,@Password,@Adress,@Email,@Phone,@CreateDate) ";
            SqlCommand command = null;
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;
                if(user != null){ 
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = user.id;
                command.Parameters.Add("@fullname", SqlDbType.NVarChar).Value = user.fullname;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = user.email;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = user.password;
                command.Parameters.Add("@googleID", SqlDbType.VarChar).Value = user.googleID;
                command.Parameters.Add("@facebookID", SqlDbType.VarChar).Value = user.facebookID;
                command.Parameters.Add("@role", SqlDbType.Int).Value = user.role;
                command.Parameters.Add("@createAt", SqlDbType.DateTime).Value = user.createAt;
                command.Parameters.Add("@modifyAt", SqlDbType.DateTime).Value = user.modifyAt;
                // thuc thi cau lenh cho (them xoa sua)
                int r = command.ExecuteNonQuery();
                //
                return true;
                }return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
        public Boolean deleteUser(int id)
        {
            SqlConnection connection = connectDatabase();
            string sql = "DELETE FROM [dbo].[User] WHERE id = @id ";
            SqlCommand command = null;
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                int r = command.ExecuteNonQuery();
                return true;
            }catch(Exception e)
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

        public User findUserByEmail(String email)
        {
            User user = null;
            List<User> list = findAll();
            foreach (User userItem in list)
            {
                if (String.Equals(email, userItem.email) == true)
                {
                    return userItem;
                }
            }
            return null;

        }
        /* public static long Insert(Student st)
{
    MySqlConnection connection = null;
    MySqlCommand command = null;
    MySqlDataReader reader = null;

    long id = -1;

    string sql = "insert into student (id, name, age, gender, address, dOB, email) " +
        "values (@id, @name, @age, @gender, @address, @dOB, @email) ";

    try
    {
        connection = DBUtils.getMySqlConnection();
        connection.Open();
        command = connection.CreateCommand();
        command.CommandText = sql;
        command.Parameters.Add("@id", MySqlDbType.Int32).Value = st.id;
        command.Parameters.Add("@name", MySqlDbType.String).Value = st.name;
        command.Parameters.Add("@age", MySqlDbType.String).Value = st.age;
        command.Parameters.Add("@gender", MySqlDbType.String).Value = st.gender;
        command.Parameters.Add("@address", MySqlDbType.String).Value = st.address;
        command.Parameters.Add("@dOB", MySqlDbType.String).Value = st.dOB;
        command.Parameters.Add("@email", MySqlDbType.String).Value = st.email;
        int r = command.ExecuteNonQuery();

        id = command.LastInsertedId;


    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e);
    }

    finally
    {
        if (connection != null)
        {
            connection.Close();
        }

        if (reader != null)
        {
            reader.Close();
        }

    }

    return id;
}*/
    }
}