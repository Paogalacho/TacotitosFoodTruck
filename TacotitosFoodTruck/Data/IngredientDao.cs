using MySql.Data.MySqlClient;
using TacotitosFoodTruck.Data;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.DAO
{
    public class IngredientDao
    {
        private readonly DatabaseConnection dbConnection;

        public IngredientDao()
        {
            dbConnection = DatabaseConnection.GetInstance();
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
                    command.Parameters.AddWithValue("@IngredientId", ingredient.Id);
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
                                Id = reader.GetInt32("ingredient_id"),
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
