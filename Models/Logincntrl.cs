using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace PoeProject.Models
{
    public class Logincntrl
    {
        public static string con_string = "Server=tcp:clouddevone.database.windows.net,1433;Initial Catalog=ST10254714CldDev;Persist Security Info=False;User ID=Caleb;Password={Liverpoolfour100};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";


        public int SelectUser(string email, string userName)
        {
            int userId = -1; 
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM dbo.userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", userName);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
            return userId;
        }

    }
}
