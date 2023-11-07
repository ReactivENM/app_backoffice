using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using System.Configuration;

namespace Models.DB
{
    class DBConnection
    {
        public DBConnection()
        {
            ConnectToDB();
        }

        private MySqlConnection connection;

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void ConnectToDB()
        {
            string server = ConfigurationSettings.AppSettings["DB_SERVER"];
            string database = ConfigurationSettings.AppSettings["DB_NAME"];
            string user = ConfigurationSettings.AppSettings["DB_USER"];
            string password = ConfigurationSettings.AppSettings["DB_PASS"];
            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                return;
            }
            
            string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection != null && connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
