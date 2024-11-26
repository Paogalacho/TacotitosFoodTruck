using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TacotitosFoodTruck.Data;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.DAO
{
    public class TacoDao
    {
        private readonly DatabaseConnection dbConnection;
        private readonly TortillaDao tortillaDao;
        private readonly IngredientDao ingredientDao;

        public TacoDao()
        {
            dbConnection = DatabaseConnection.GetInstance();
            tortillaDao = new TortillaDao();
            ingredientDao = new IngredientDao();
        }

        public int AddTaco(Taco taco)
        {
            int tacoId = 0; // Inicializa el ID del taco

            // Calculamos el precio total antes de la inserción
            taco.CalculateTotalPrice(); 

            using (var connection = dbConnection.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar el taco en la tabla 'taco'
                        string insertTacoQuery = @"INSERT INTO taco (name, total_price, sauce_id, created_at)
                                           VALUES (@name, @totalPrice, @sauceId, @createdAt)";
                        using (var cmd = new MySqlCommand(insertTacoQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", taco.Name);
                            cmd.Parameters.AddWithValue("@totalPrice", taco.TotalPrice);  // Usar el precio total calculado
                            cmd.Parameters.AddWithValue("@sauceId", taco.Sauce?.SauceId ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@createdAt", taco.CreatedAt);

                            cmd.ExecuteNonQuery();
                            tacoId = (int)cmd.LastInsertedId; // Obtiene el ID del taco recién insertado
                        }

                        // Insertar las tortillas asociadas
                        InsertTortillas(tacoId, taco.Tortillas, connection, transaction);

                        // Insertar los ingredientes asociados
                        InsertIngredients(tacoId, taco.Ingredients, connection, transaction);

                        // Confirmamos la transacción
                        transaction.Commit();
                    }
                    catch
                    {
                        // En caso de error, hacemos rollback
                        transaction.Rollback();
                        throw new Exception("Error while adding the taco. Transaction rolled back.");
                    }
                }
            }
            return tacoId; // Retorna el ID del taco creado
        }



        private void InsertTortillas(int tacoId, List<Tortilla> tortillas, MySqlConnection connection, MySqlTransaction transaction)
        {
            string tortillaQuery = "INSERT INTO taco_tortilla (taco_id, tortilla_id) VALUES (@taco_id, @tortilla_id)";
            foreach (var tortilla in tortillas)
            {
                using (var tortillaCommand = new MySqlCommand(tortillaQuery, connection, transaction))
                {
                    tortillaCommand.Parameters.AddWithValue("@taco_id", tacoId);
                    tortillaCommand.Parameters.AddWithValue("@tortilla_id", tortilla.TortillaId);
                    tortillaCommand.ExecuteNonQuery();
                }
            }
        }

        private void InsertIngredients(int tacoId, List<Ingredient> ingredients, MySqlConnection connection, MySqlTransaction transaction)
         {
             string ingredientQuery = "INSERT INTO taco_ingredient (taco_id, ingredient_id) VALUES (@taco_id, @ingredient_id)";
             foreach (var ingredient in ingredients)
             {
                 using (var ingredientCommand = new MySqlCommand(ingredientQuery, connection, transaction))
                 {
                     ingredientCommand.Parameters.AddWithValue("@taco_id", tacoId);
                     ingredientCommand.Parameters.AddWithValue("@ingredient_id", ingredient.IngredientId);
                     ingredientCommand.ExecuteNonQuery();
                 }
             }
         }



        public Taco GetTacoWithDetails(int tacoId)
        {
            Taco taco = null;
            using (var connection = dbConnection.GetConnection())
            {
                string query = @"SELECT t.*, s.name AS sauce_name, s.price AS sauce_price
                         FROM taco t
                         LEFT JOIN sauce s ON t.sauce_id = s.sauce_id
                         WHERE t.taco_id = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", tacoId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taco = MapTaco(reader);
                            taco.Tortillas = tortillaDao.GetTortillasByTacoId(taco.TacoId);
                            taco.Ingredients = ingredientDao.GetIngredientsByTacoId(taco.TacoId);
                        }
                    }
                }
            }
            return taco;
        }



        public Taco GetTacoById(int tacoId)
        {
            Taco taco = null;
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "SELECT * FROM taco WHERE taco_id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", tacoId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taco = MapTaco(reader);
                        }
                    }
                }
            }

        
            return taco;
        }

        public List<Taco> GetAllTacos()
        {
            var tacos = new List<Taco>();
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "SELECT * FROM taco";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var taco = MapTaco(reader);
                            // Cargar tortillas e ingredientes asociados
                            taco.Tortillas = tortillaDao.GetTortillasByTacoId(taco.TacoId);
                            taco.Ingredients = ingredientDao.GetIngredientsByTacoId(taco.TacoId);
                            tacos.Add(taco);
                        }
                    }
                }
            }
            return tacos;
        }

        


        

        // Obtener el taco más económico
        public Taco GetCheapestTaco()
        {
            Taco taco = null;
            using (var connection = dbConnection.GetConnection())
            {
                string query = @"
                SELECT taco.*, SUM(tortilla.price) + SUM(ingredient.price) + IFNULL(sauce.price, 0) AS total_price
                FROM taco
                LEFT JOIN taco_tortilla tt ON taco.taco_id = tt.taco_id
                LEFT JOIN tortilla ON tt.tortilla_id = tortilla.tortilla_id
                LEFT JOIN taco_ingredient ti ON taco.taco_id = ti.taco_id
                LEFT JOIN ingredient ON ti.ingredient_id = ingredient.ingredient_id
                LEFT JOIN sauce ON taco.sauce_id = sauce.sauce_id
                GROUP BY taco.taco_id
                ORDER BY total_price ASC
                LIMIT 1";  // Solo el más barato

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taco = MapTaco(reader);
                            taco.TotalPrice = reader.GetDecimal("total_price");
                        }
                    }
                }
            }
            return taco;
        }

        // Obtener el taco más costoso
        public Taco GetMostExpensiveTaco()
        {
            Taco taco = null;
            using (var connection = dbConnection.GetConnection())
            {
                string query = @"
                SELECT taco.*, SUM(tortilla.price) + SUM(ingredient.price) + IFNULL(sauce.price, 0) AS total_price
                FROM taco
                LEFT JOIN taco_tortilla tt ON taco.taco_id = tt.taco_id
                LEFT JOIN tortilla ON tt.tortilla_id = tortilla.tortilla_id
                LEFT JOIN taco_ingredient ti ON taco.taco_id = ti.taco_id
                LEFT JOIN ingredient ON ti.ingredient_id = ingredient.ingredient_id
                LEFT JOIN sauce ON taco.sauce_id = sauce.sauce_id
                GROUP BY taco.taco_id
                ORDER BY total_price DESC
                LIMIT 1";  // Solo el más caro

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taco = MapTaco(reader);
                            taco.TotalPrice = reader.GetDecimal("total_price");
                        }
                    }
                }
            }
            return taco;
        }


        public decimal GetAveragePrice()
        {
            decimal averagePrice = 0;
            using (var connection = dbConnection.GetConnection())
            {
                // Consulta para obtener el promedio de los precios totales de los tacos
                string getAveragePriceQuery = "SELECT AVG(total_price) AS average_price FROM taco";

                using (var command = new MySqlCommand(getAveragePriceQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Verificamos si el resultado es DBNull y lo manejamos
                            averagePrice = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);

                            // Redondeamos el promedio a 2 decimales
                            averagePrice = Math.Round(averagePrice, 2);
                        }
                    }
                }
            }
            return averagePrice;
        }






        // Método auxiliar para mapear el taco
        private Taco MapTaco(MySqlDataReader reader)
        {
            return new Taco
            {
                TacoId = reader.GetInt32("taco_id"),
                Name = reader.GetString("name"),
                TotalPrice = reader.GetDecimal("total_price"),
                Sauce = new Sauce
                {
                    SauceId = reader.GetInt32("sauce_id"),
                    Name = reader.GetString("name"),
                    Price = reader.GetDecimal("price")
                },
                CreatedAt = reader.GetDateTime("created_at")
            };
        }




    }
}
