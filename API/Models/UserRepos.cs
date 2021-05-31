using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DatabaseAccess;
namespace API.Models
{
    public class UserRepos : IUser
    {
        public static SqlConnection connectDatabase()
        {
            string connectionString = "Data Source=LAPTOP-7OO41Q78\\DCT;Initial Catalog=Project;Integrated Security=True";
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

        public User findIdUser(int id)
        {
            User user = null;
            List<User> list = findAll();
            foreach(User index in list)
            {
                if(index.id == id)
                {
                    user = index;
                }
            }
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
                command.Parameters.Add("@id", SqlDbType.Int).Value = user.id;
                command.Parameters.Add("@Fullnname", SqlDbType.NVarChar).Value = user.Fullnname;
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                command.Parameters.Add("@Adress", SqlDbType.NVarChar).Value = user.Adress;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = user.Phone;
                command.Parameters.Add("@CreateDate", SqlDbType.DateTime2).Value = user.CreateDate;
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