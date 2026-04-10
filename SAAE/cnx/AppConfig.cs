using System;
using System.Configuration;

namespace SAAE.cnx
{
    /// <summary>
    /// Clase para manejar la configuración de la aplicación
    /// Útil para cambiar parámetros sin recompilar
    /// </summary>
    public static class AppConfig
    {
        // Configuración de la base de datos
        public static class Database
        {
            public const string Server = "MAM-IVT-PC-13\\SQLEXPRESS";
            public const string DatabaseName = "SAAE";
            public const string UserId = "sa";
            public const string Password = "T3ch4dm1n";
            
            public static string GetConnectionString()
            {
                return $"Server={Server};Database={DatabaseName};User Id={UserId};Password={Password};TrustServerCertificate=True;";
            }
        }

        // Configuración de la aplicación
        public static class Application
        {
            public const string Name = "SAAE";
            public const string FullName = "Sistema Automatizado de Asistencia Escolar";
            public const string Version = "0.0.1A";
            public const string Author = "Javier Nieto";
            public const int Year = 2026;
        }

        // Configuración de seguridad
        public static class Security
        {
            public const int MaxLoginAttempts = 3;
            public const int SessionTimeoutMinutes = 30;
            public const bool RequireStrongPassword = false;
            public const int MinPasswordLength = 6;
        }
    }
}
