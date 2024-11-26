using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TacotitosFoodTruck.Data;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.DAO
{
    public class SauceDao
    {
        private readonly DatabaseConnection dbConnection;

        public SauceDao()
        {
            dbConnection = DatabaseConnection.GetInstance();
        }

        // Obtener salsas por sus IDs
        public List<Sauce> GetSaucesByIds(int[] sauceIds)
        {
            var sauces = new List<Sauce>();
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = $"SELECT * FROM sauce WHERE sauce_id IN ({string.Join(",", sauceIds)})";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sauces.Add(new Sauce
                            {
                                SauceId = reader.GetInt32("sauce_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return sauces;
        }

        // Obtener todas las salsas
        public List<Sauce> GetAllSauces()
        {
            var sauces = new List<Sauce>();
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "SELECT * FROM sauce";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sauces.Add(new Sauce
                            {
                                SauceId = reader.GetInt32("sauce_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return sauces;
        }

        // Agregar una nueva salsa
        public void AddSauce(Sauce sauce)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "INSERT INTO sauce (name, price) VALUES (@name, @price)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", sauce.Name);
                    command.Parameters.AddWithValue("@price", sauce.Price);

                    command.ExecuteNonQuery();
                    sauce.SauceId = (int)command.LastInsertedId;
                }
            }
        }

        // Actualizar una salsa existente
        public void UpdateSauce(Sauce sauce)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "UPDATE sauce SET name = @name, price = @price WHERE sauce_id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", sauce.SauceId);
                    command.Parameters.AddWithValue("@name", sauce.Name);
                    command.Parameters.AddWithValue("@price", sauce.Price);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una salsa por su ID
        public void DeleteSauce(int sauceId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "DELETE FROM sauce WHERE sauce_id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", sauceId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
