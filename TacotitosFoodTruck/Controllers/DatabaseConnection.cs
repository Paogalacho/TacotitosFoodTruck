using MySql.Data.MySqlClient;
using System;

namespace TacotitosFoodTruck.Data
{
    public class DatabaseConnection
    {
        private static readonly DatabaseConnection instance = new DatabaseConnection();
        private readonly string connectionString = "Server=127.0.0.1;Database=tacotitosdb;Uid=root;Pwd=;";
        private MySqlConnection connection;

        // Constructor privado para el patrón Singleton
        private DatabaseConnection() { }

        /// <summary>
        /// Devuelve la instancia única del singleton.
        /// </summary>
        public static DatabaseConnection GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Intenta abrir la conexión a la base de datos.
        /// </summary>
        /// <returns>Una instancia de MySqlConnection abierta.</returns>
        public MySqlConnection Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection; // Retornamos la conexión abierta
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to the database: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Devuelve la conexión activa si ya existe.
        /// </summary>
        public MySqlConnection GetConnection()
        {
            if (connection == null || connection.State == System.Data.ConnectionState.Closed)
            {
                throw new InvalidOperationException("No active connection. Call Connect() first.");
            }
            return connection;
        }

        /// <summary>
        /// Cierra la conexión si está abierta.
        /// </summary>
        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}

