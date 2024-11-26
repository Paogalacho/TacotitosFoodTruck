using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TacotitosFoodTruck.Data;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.DAO
{
    public class TortillaDao
    {
        private readonly DatabaseConnection dbConnection;

        public TortillaDao()
        {
            dbConnection = DatabaseConnection.GetInstance();
        }

        // Obtener tortillas por sus IDs
        public List<Tortilla> GetTortillasByIds(int[] tortillaIds)
        {
            var tortillas = new List<Tortilla>();
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = $"SELECT * FROM tortilla WHERE tortilla_id IN ({string.Join(",", tortillaIds)})";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tortillas.Add(new Tortilla
                            {
                                TortillaId = reader.GetInt32("tortilla_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return tortillas;
        }

        // Obtener todas las tortillas
        public List<Tortilla> GetAllTortillas()
        {
            var tortillas = new List<Tortilla>();
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "SELECT * FROM tortilla";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tortillas.Add(new Tortilla
                            {
                                TortillaId = reader.GetInt32("tortilla_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return tortillas;
        }
        public List<Tortilla> GetTortillasByTacoId(int tacoId)
        {
            var tortillas = new List<Tortilla>();
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();
                string query = "SELECT t.* FROM tortilla t " +
                               "INNER JOIN taco_tortilla tt ON t.tortilla_id = tt.tortilla_id " +
                               "WHERE tt.taco_id = @taco_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taco_id", tacoId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tortilla = new Tortilla
                            {
                                TortillaId = reader.GetInt32("tortilla_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            };
                            tortillas.Add(tortilla);
                        }
                    }
                }
            }
            return tortillas;
        }


        // Agregar una nueva tortilla
        public void AddTortilla(Tortilla tortilla)
        {
            using (var connection = dbConnection.GetConnection())
            {
                string query = "INSERT INTO tortilla (name, price) VALUES (@name, @price)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", tortilla.Name);
                    command.Parameters.AddWithValue("@price", tortilla.Price);

                    command.ExecuteNonQuery();
                    tortilla.TortillaId = (int)command.LastInsertedId;  // Obtener el ID generado
                }
            }
        }

        // Actualizar una tortilla existente
        public void UpdateTortilla(Tortilla tortilla)
        {
            using (var connection = dbConnection.GetConnection())
            {
                string query = "UPDATE tortilla SET name = @name, price = @price WHERE tortilla_id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", tortilla.TortillaId);
                    command.Parameters.AddWithValue("@name", tortilla.Name);
                    command.Parameters.AddWithValue("@price", tortilla.Price);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una tortilla por su ID
        public void DeleteTortilla(int tortillaId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "DELETE FROM tortilla WHERE tortilla_id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", tortillaId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
