using MySql.Data.MySqlClient;
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
                                Id = reader.GetInt32("tortilla_id"),
                                Name = reader.GetString("name"),
                                Price = reader.GetDecimal("price")
                            });
                        }
                    }
                }
            }
            return tortillas;
        }
   
        
        public void AddTortilla(Tortilla tortilla)
        {
            using (var connection = dbConnection.GetConnection())
            {
                string query = "INSERT INTO tortilla (name, price) VALUES (@Name, @Price)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", tortilla.Name);
                    command.Parameters.AddWithValue("@Price", tortilla.Price);
                    command.ExecuteNonQuery();
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
                    command.Parameters.AddWithValue("@id", tortilla.Id);
                    command.Parameters.AddWithValue("@name", tortilla.Name);
                    command.Parameters.AddWithValue("@price", tortilla.Price);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar una tortilla por su ID
        public void DeleteTortilla(int Id)
        {
            using (var connection = dbConnection.GetConnection())
            {
                
                string query = "DELETE FROM tortilla WHERE tortilla_id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
