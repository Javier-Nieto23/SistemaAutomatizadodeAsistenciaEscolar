using System;
using Microsoft.Data.SqlClient;

namespace SAAE.cnx
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            _connectionString = AppConfig.Database.GetConnectionString();
        }

        public SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear la conexión: {ex.Message}");
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al probar la conexión: {ex.Message}");
            }
        }
    }
}
