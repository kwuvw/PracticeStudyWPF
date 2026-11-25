using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Shop.Data
{
    internal class Database
    {
        
        private static readonly string connectionString =
            @"Server=localhost;
              Database=ShoeStoreDb;
              Integrated Security=True;
              TrustServerCertificate=True;";


        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool LoginExists(string login)
        {
            using var connection = GetConnection();
            connection.Open();


            string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", login);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
    }
}
