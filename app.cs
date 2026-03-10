using System;
using System.Data.SqlClient;
using System.Web;

namespace TestApp
{
    public class UserController
    {
        private string connectionString = "Server=localhost;Database=Users;";

        public string GetUser(string userId)
        {
            // SQL injection vulnerability (intentional for SAST test)
            string query = "SELECT * FROM Users WHERE Id = " + userId;
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            return cmd.ExecuteScalar()?.ToString();
        }

        public string RenderProfile(string username)
        {
            // XSS vulnerability (intentional for SAST test)
            return "<div>Welcome " + username + "</div>";
        }
    }
}
