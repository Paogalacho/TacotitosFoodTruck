using TacotitosFoodTruck.Controllers;
using TacotitosFoodTruck.Model;


namespace TacotitosFoodTruck.Views
{
    public partial class AdminForm : Form
    {
        private readonly ProductController productController = new ProductController();
        private readonly TacoController tacoController = new TacoController();

        public AdminForm()
        {
            InitializeComponent();
            LoadIngredients(); // Cargar ingredientes al inicializar
            LoadTortillas();
            LoadSalsas();
            LoadTacos();
        }

        // Cargar ingredientes en el DataGridView
        private void LoadIngredients()
        {
            try
            {
                var ingredients = productController.GetAllIngredients();
                dgvIngredients.DataSource = null;
                dgvIngredients.DataSource = ingredients
                    .Select(i => new { i.Id, i.Name, i.Price }) // Mostrar solo columnas necesarias
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ingredientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Agregar ingrediente
        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Ingrese el nombre del ingrediente:", "Agregar Ingrediente");
            if (string.IsNullOrWhiteSpace(name)) return;

            string priceInput = Prompt.ShowDialog("Ingrese el precio del ingrediente:", "Agregar Ingrediente");
            if (!decimal.TryParse(priceInput, out decimal price))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                productController.AddIngredient(name, price);
                LoadIngredients(); // Refrescar la tabla
                MessageBox.Show("Ingrediente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar ingrediente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editar ingrediente
        private void btnEditIngredient_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (dgvIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener la fila seleccionada
                var selectedRow = dgvIngredients.SelectedRows[0];

                // Asegurarse de que el valor de la celda "Id" no sea nulo
                if (selectedRow.Cells["Id"].Value == null)
                {
                    MessageBox.Show("El ID no puede ser nulo. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener valores de la fila seleccionada
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value); // Asegurar conversión
                string currentName = selectedRow.Cells["Name"].Value?.ToString();
                decimal currentPrice = Convert.ToDecimal(selectedRow.Cells["Price"].Value);

                // Mostrar diálogo para editar el nombre
                string newName = Prompt.ShowDialog($"Editar nombre ({currentName}):", "Editar Ingrediente", currentName);
                if (string.IsNullOrWhiteSpace(newName)) return;

                // Mostrar diálogo para editar el precio
                string priceInput = Prompt.ShowDialog($"Editar precio ({currentPrice:C}):", "Editar Ingrediente", currentPrice.ToString());
                if (!decimal.TryParse(priceInput, out decimal newPrice))
                {
                    MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el objeto actualizado
                var ingredient = new Ingredient { Id = id, Name = newName, Price = newPrice };

                // Llamar al controlador para actualizar
                productController.UpdateIngredient(ingredient);
                LoadIngredients(); // Refrescar la tabla

                MessageBox.Show("Ingrediente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar ingrediente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar ingrediente
        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (dgvIngredients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ingrediente para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvIngredients.SelectedRows[0];
            int id = (int)selectedRow.Cells["Id"].Value;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este ingrediente?", "Confirmar Eliminación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    productController.DeleteIngredient(id);
                    LoadIngredients(); // Refrescar la tabla
                    MessageBox.Show("Ingrediente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar ingrediente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Cargar todas las tortillas en el DataGridView
        private void LoadTortillas()
        {
            try
            {
                var tortillas = productController.GetAllTortillas();
                dgvTortillas.DataSource = tortillas
                    .Select(t => new { t.Id, t.Name, t.Price }) // Mostrar solo columnas necesarias
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las tortillas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Agregar tortilla
        private void btnAddTortilla_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Ingrese el nombre de la tortilla:", "Agregar Tortilla");
            if (string.IsNullOrWhiteSpace(name)) return;

            string priceInput = Prompt.ShowDialog("Ingrese el precio de la tortilla:", "Agregar Tortilla");
            if (!decimal.TryParse(priceInput, out decimal price))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                productController.AddTortilla(name, price);  // Llamar al controlador para agregar la tortilla
                LoadTortillas();  // Refrescar la tabla de tortillas
                MessageBox.Show("Tortilla agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar tortilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editar tortilla
        private void btnEditTortilla_Click(object sender, EventArgs e)
        {
            if (dgvTortillas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tortilla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvTortillas.SelectedRows[0];
            int id = (int)selectedRow.Cells["Id"].Value;
            string currentName = (string)selectedRow.Cells["Name"].Value;
            decimal currentPrice = (decimal)selectedRow.Cells["Price"].Value;

            string newName = Prompt.ShowDialog($"Editar nombre ({currentName}):", "Editar Tortilla", currentName);
            if (string.IsNullOrWhiteSpace(newName)) return;

            string priceInput = Prompt.ShowDialog($"Editar precio ({currentPrice:C}):", "Editar Tortilla", currentPrice.ToString());
            if (!decimal.TryParse(priceInput, out decimal newPrice))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var tortilla = new Tortilla { Id = id, Name = newName, Price = newPrice };
                productController.UpdateTortilla(tortilla);
                LoadTortillas();  // Refrescar la tabla
                MessageBox.Show("Tortilla actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar tortilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar tortilla
        private void btnDeleteTortilla_Click(object sender, EventArgs e)
        {
            if (dgvTortillas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tortilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvTortillas.SelectedRows[0];
            int id = (int)selectedRow.Cells["Id"].Value;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar esta tortilla?", "Confirmar Eliminación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    productController.DeleteTortilla(id);
                    LoadTortillas();  // Refrescar la tabla
                    MessageBox.Show("Tortilla eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar tortilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Cargar salsas en el DataGridView
        private void LoadSalsas()
        {
            try
            {
                var salsas = productController.GetAllSauces();
                dgvSalsas.DataSource = null;
                dgvSalsas.DataSource = salsas
                    .Select(s => new { s.SauceId, s.Name, s.Price }) // Mostrar solo columnas necesarias
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las salsas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Agregar salsa
        private void btnAddSalsa_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Ingrese el nombre de la salsa:", "Agregar Salsa");
            if (string.IsNullOrWhiteSpace(name)) return;

            string priceInput = Prompt.ShowDialog("Ingrese el precio de la salsa:", "Agregar Salsa");
            if (!decimal.TryParse(priceInput, out decimal price))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                productController.AddSauce(name, price);
                LoadSalsas(); // Refrescar la tabla
                MessageBox.Show("Salsa agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar salsa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editar salsa
        private void btnEditSalsa_Click(object sender, EventArgs e)
        {
            if (dgvSalsas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una salsa para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvSalsas.SelectedRows[0];
            int id = (int)selectedRow.Cells["SauceId"].Value;
            string currentName = (string)selectedRow.Cells["Name"].Value;
            decimal currentPrice = (decimal)selectedRow.Cells["Price"].Value;


            string newName = Prompt.ShowDialog($"Editar nombre ({currentName}):", "Editar Salsa", currentName);
            if (string.IsNullOrWhiteSpace(newName)) return;

            string priceInput = Prompt.ShowDialog($"Editar precio ({currentPrice:C}):", "Editar Salsa", currentPrice.ToString());
            if (!decimal.TryParse(priceInput, out decimal newPrice))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var salsa = new Sauce { SauceId = id, Name = newName, Price = newPrice };
                productController.UpdateSauce(salsa);
                LoadSalsas(); // Refrescar la tabla
                MessageBox.Show("Salsa actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar salsa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar salsa
        private void btnDeleteSalsa_Click(object sender, EventArgs e)
        {
            if (dgvSalsas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una salsa para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvSalsas.SelectedRows[0];
            int id = (int)selectedRow.Cells["SauceId"].Value;

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar esta salsa?", "Confirmar Eliminación",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    productController.DeleteSauce(id);
                    LoadSalsas(); // Refrescar la tabla
                    MessageBox.Show("Salsa eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar salsa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Listar tacos
        private void LoadTacos()
        {
            try
            {
                var tacos = tacoController.GetAllTacos();
                dgvTacos.DataSource = null;
                dgvTacos.DataSource = tacos
                    .Select(t => new
                    {
                        t.TacoId,
                        t.Name,
                        Tortillas = string.Join(", ", t.Tortillas.Select(tor => tor.Name)),
                        Ingredientes = string.Join(", ", t.Ingredients.Select(ing => ing.Name)),
                        Salsa = t.Sauce?.Name ?? "Sin Salsa",
                        t.TotalPrice,
                        t.CreatedAt,
                    })
                    .ToList();

                dgvTacos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tacos: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Consultar taco más barato
        private void btnCheapestTaco_Click(object sender, EventArgs e)
        {
            try
            {
                var taco = tacoController.GetCheapestTaco();
                if (taco != null)
                {
                    MessageBox.Show($"Taco más barato:\n\nNombre: {taco.Name}\nPrecio: {taco.TotalPrice:C}\n", "Consulta");
                }
                else
                {
                    MessageBox.Show("No hay tacos registrados.", "Información");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar taco más barato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Consultar taco más caro
        private void btnMostExpensiveTaco_Click(object sender, EventArgs e)
        {
            try
            {
                var taco = tacoController.GetMostExpensiveTaco();
                if (taco != null)
                {
                    MessageBox.Show($"Taco más caro:\n\nNombre: {taco.Name}\nPrecio: {taco.TotalPrice:C}\n", "Consulta");
                }
                else
                {
                    MessageBox.Show("No hay tacos registrados.", "Información");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar taco más caro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Consultar precio promedio de tacos
        private void btnAverageTacoPrice_Click(object sender, EventArgs e)
        {
            try
            {
                var avgPrice = tacoController.GetAveragePrice();
                MessageBox.Show($"El precio promedio de los tacos es: {avgPrice:C}", "Consulta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar precio promedio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
