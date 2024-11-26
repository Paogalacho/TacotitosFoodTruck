using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TacotitosFoodTruck.Data;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.DAO
{
    public class IngredientDao
    {
        private readonly DatabaseConnection dbConnection;


        // Constructor con un argumento
        public IngredientDao(string connectionString)
        {
            dbConnection = DatabaseConnection.GetInstance();
        }

        public IngredientDao()
        {
            dbConnection = DatabaseConnection.GetInstance();
        }

        public List<Ingredient> GetIngredientsByIds(int[] ingredientIds)
        {
            var ingredients = new List<Ingredient>();
            using (var connection = dbConnection.GetConnection())
            {
                string query = $"SELECT * FROM ingredient WHERE ingredient_id IN ({string.Join(",", ingredientIds)})";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredients.Add(new Ingredient
                            {
                                IngredientId = reader.GetInt32("ingredient_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return ingredients;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "INSERT INTO ingredient (name, price) VALUES (@Name, @Price)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Price", ingredient.Price);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "UPDATE ingredient SET name = @Name, price = @Price WHERE ingredient_id = @IngredientId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IngredientId", ingredient.IngredientId);
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Price", ingredient.Price);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "DELETE FROM ingredient WHERE ingredient_id = @IngredientId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IngredientId", ingredientId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Ingredient> GetAllIngredients()
        {
            var ingredients = new List<Ingredient>();
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "SELECT ingredient_id, name, price FROM ingredient";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredients.Add(new Ingredient
                            {
                                IngredientId = reader.GetInt32("ingredient_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return ingredients;
        }
        
        public List<Ingredient> GetIngredientsByTacoId(int tacoId)
        {
            var ingredients = new List<Ingredient>();
            using (var connection = dbConnection.GetConnection())
            {
                string query = @"SELECT i.*
                         FROM ingredient i
                         INNER JOIN taco_ingredient ti ON i.ingredient_id = ti.ingredient_id
                         WHERE ti.taco_id = @taco_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@taco_id", tacoId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredients.Add(new Ingredient
                            {
                                IngredientId = reader.GetInt32("ingredient_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return ingredients;
        }

    }
}
