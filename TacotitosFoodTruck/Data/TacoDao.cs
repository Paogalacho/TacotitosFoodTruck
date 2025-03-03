using MySql.Data.MySqlClient;
using TacotitosFoodTruck.Data;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.DAO
{
    public class TacoDao
    {
        private readonly DatabaseConnection dbConnection;
      

        public TacoDao()
        {
            dbConnection = DatabaseConnection.GetInstance();
            
        }


        public int AddTaco(Taco taco)
        {
            int tacoId = 0;
            taco.CalculateTotalPrice();


            using (var connection = dbConnection.GetConnection())
            {
                // Insert the taco
                string insertTacoQuery = @"INSERT INTO taco (name, total_price, sauce_id, created_at)
                                           VALUES (@name, @totalPrice, @sauceId, @createdAt);
                                           SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(insertTacoQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@name", taco.Name);
                    cmd.Parameters.AddWithValue("@totalPrice", taco.TotalPrice);
                    cmd.Parameters.AddWithValue("@sauceId",
                        taco.Sauce?.SauceId > 0
                            ? (object)taco.Sauce.SauceId
                            : DBNull.Value);
                    cmd.Parameters.AddWithValue("@createdAt", taco.CreatedAt);

                    tacoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Insert tortillas
                foreach (var tortilla in taco.Tortillas)
                {
                    string insertTortillaQuery = "INSERT INTO taco_tortilla (taco_id, tortilla_id) VALUES (@tacoId, @tortillaId)";
                    using (var cmd = new MySqlCommand(insertTortillaQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@tacoId", tacoId);
                        cmd.Parameters.AddWithValue("@tortillaId", tortilla.Id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Insert ingredients
                foreach (var ingredient in taco.Ingredients)
                {
                    string insertIngredientQuery = "INSERT INTO taco_ingredient (taco_id, ingredient_id) VALUES (@tacoId, @ingredientId)";
                    using (var cmd = new MySqlCommand(insertIngredientQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@tacoId", tacoId);
                        cmd.Parameters.AddWithValue("@ingredientId", ingredient.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return tacoId;
        }


        public List<Taco> GetAllTacos()
        {
            Dictionary<int, Taco> tacos = new Dictionary<int, Taco>();
            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                string query = @"
    SELECT t.taco_id, t.name, t.total_price, t.sauce_id, t.created_at,
           s.name as sauce_name, s.price as sauce_price,
           tor.tortilla_id, tor.name as tortilla_name, tor.price as tortilla_price,
           ing.ingredient_id, ing.name as ingredient_name, ing.price as ingredient_price
    FROM taco t
    LEFT JOIN sauce s ON t.sauce_id = s.sauce_id
    LEFT JOIN taco_tortilla tt ON t.taco_id = tt.taco_id
    LEFT JOIN tortilla tor ON tt.tortilla_id = tor.tortilla_id
    LEFT JOIN taco_ingredient ti ON t.taco_id = ti.taco_id
    LEFT JOIN ingredient ing ON ti.ingredient_id = ing.ingredient_id
    ORDER BY t.taco_id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tacoId = reader.GetInt32("taco_id");
                            if (!tacos.ContainsKey(tacoId))
                            {
                                Taco taco = new Taco();
                                taco.TacoId = tacoId;
                                taco.Name = reader.GetString("name");
                                taco.TotalPrice = reader.GetDecimal("total_price");
                                taco.CreatedAt = reader.GetDateTime("created_at");
                                taco.Tortillas = new List<Tortilla>();
                                taco.Ingredients = new List<Ingredient>();

                                if (!reader.IsDBNull(reader.GetOrdinal("sauce_name")))
                                {
                                    Sauce sauce = new Sauce();
                                    sauce.SauceId = reader.GetInt32("sauce_id");
                                    sauce.Name = reader.GetString("sauce_name");
                                    sauce.Price = reader.GetDecimal("sauce_price");
                                    taco.Sauce = sauce;
                                }

                                tacos[tacoId] = taco;
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("tortilla_id")))
                            {
                                Tortilla tortilla = new Tortilla();
                                tortilla.Id = reader.GetInt32("tortilla_id");
                                tortilla.Name = reader.GetString("tortilla_name");
                                tortilla.Price = reader.GetDecimal("tortilla_price");

                                bool tortillaExists = false;
                                foreach (Tortilla existingTortilla in tacos[tacoId].Tortillas)
                                {
                                    if (existingTortilla.Id == tortilla.Id)
                                    {
                                        tortillaExists = true;
                                        break;
                                    }
                                }

                                if (!tortillaExists)
                                {
                                    tacos[tacoId].Tortillas.Add(tortilla);
                                }
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("ingredient_id")))
                            {
                                Ingredient ingredient = new Ingredient();
                                ingredient.Id = reader.GetInt32("ingredient_id");
                                ingredient.Name = reader.GetString("ingredient_name");
                                ingredient.Price = reader.GetDecimal("ingredient_price");

                                bool ingredientExists = false;
                                foreach (Ingredient existingIngredient in tacos[tacoId].Ingredients)
                                {
                                    if (existingIngredient.Id == ingredient.Id)
                                    {
                                        ingredientExists = true;
                                        break;
                                    }
                                }

                                if (!ingredientExists)
                                {
                                    tacos[tacoId].Ingredients.Add(ingredient);
                                }
                            }
                        }
                    }
                }
            }

            List<Taco> tacoList = new List<Taco>();
            foreach (Taco taco in tacos.Values)
            {
                tacoList.Add(taco);
            }
            return tacoList;
        }

        // Obtener el taco más económico
        public Taco GetCheapestTaco()
        {
            Taco taco = null;
            using (var connection = dbConnection.GetConnection())
            {
                string query = @"
                SELECT 
                taco.taco_id, 
                taco.name, 
                taco.total_price, 
                taco.created_at
                FROM taco
                ORDER BY taco.total_price ASC
                LIMIT 1";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taco = new Taco
                            {
                                TacoId = reader.GetInt32("taco_id"),
                                Name = reader.GetString("name"),
                                TotalPrice = reader.GetDecimal("total_price"),
                                CreatedAt = reader.GetDateTime("created_at")
                            };
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
            SELECT 
                taco.taco_id, 
                taco.name, 
                taco.total_price, 
                taco.created_at
            FROM taco
            ORDER BY taco.total_price DESC
            LIMIT 1";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taco = new Taco
                            {
                                TacoId = reader.GetInt32("taco_id"),
                                Name = reader.GetString("name"),
                                TotalPrice = reader.GetDecimal("total_price"),
                                CreatedAt = reader.GetDateTime("created_at")
                            };
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

    }
}

