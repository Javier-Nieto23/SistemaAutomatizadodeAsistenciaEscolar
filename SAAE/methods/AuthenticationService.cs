using System;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using SAAE.cnx;

namespace SAAE.methods
{
    public class AuthenticationService
    {
        private readonly DatabaseConnection _dbConnection;

        public AuthenticationService()
        {
            _dbConnection = new DatabaseConnection();
        }

        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("El usuario y contraseña son obligatorios.");
            }

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT password_hash, activo 
                                   FROM usuarios 
                                   WHERE username = @username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["password_hash"].ToString();
                                bool isActive = Convert.ToBoolean(reader["activo"]);

                                if (!isActive)
                                {
                                    throw new Exception("El usuario está inactivo.");
                                }

                                string passwordHash = HashPassword(password);
                                return storedHash == passwordHash;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar usuario: {ex.Message}");
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool CreateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("El usuario y contraseña son obligatorios.");
            }

            try
            {
                using (SqlConnection connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"INSERT INTO usuarios (username, password_hash, activo) 
                                   VALUES (@username, @password_hash, 1)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password_hash", HashPassword(password));

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear usuario: {ex.Message}");
            }
        }
    }
}
