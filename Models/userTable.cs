using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PoeProject.Models
{
    public class userTable
    {


        public static string con_string = "Server=tcp:clouddevone.database.windows.net,1433;Initial Catalog=ST10254714CldDev;Persist Security Info=False;User ID=Caleb;Password=Liverpoolfour100;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";


        public static SqlConnection con = new SqlConnection(con_string);



        public string userName { get; set; }

        public string userPassword { get; set; }

        public string userEmail { get; set; }





        public int insert_User(userTable m)
        {
            string connectionString = GetAzureConnectionString();

            string sql = "INSERT INTO userTable (userName, userEmail, userPassword) VALUES (@UserName, @Email, @Password)";
            //string sql = "INSERT INTO dbo.productTable (name, price, category, availability) VALUES ('Test Product', 10.99, 'Category 1', 1);";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@UserName", m.userName);
                    cmd.Parameters.AddWithValue("@Password", m.userPassword);
                    cmd.Parameters.AddWithValue("@Email", m.userEmail);

                    con.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    con.Close();

                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            /*
            try
            {
                string sql = "INSERT INTO dbo.userTable (userName, userEmail, userPassword) VALUES (@UserName, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Username", m.userName);
                cmd.Parameters.AddWithValue("@Password", m.password);
                cmd.Parameters.AddWithValue("@Email", m.email);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected; 
            }
            catch (Exception ex)
            {
                throw ex;
            }

            */
        }
        private string GetAzureConnectionString()
        {
           
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Retrieve the connection string from configuration
            string connectionString = config.GetConnectionString("ST10254714CldDev");

            return connectionString;
        }

    }
}
