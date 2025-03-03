using System;
using System.ComponentModel;
using System.Windows.Forms;
using TacotitosFoodTruck.Controllers;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.Views
{
    public partial class ClientForm : Form
    {
        private readonly ProductController productController;
        private readonly TacoController tacoController;
        private Taco currentTaco;

        public ClientForm()
        {
            InitializeComponent();
            productController = new ProductController();
            tacoController = new TacoController();
            currentTaco = new Taco();
            LoadProducts();
            SetupDataGridView();

            checkedListBoxTortillas.ItemCheck += checkedListBoxTortillas_ItemCheck;
            checkedListBoxIngredients.ItemCheck += checkedListBoxIngredients_ItemCheck;
            comboBoxSauces.SelectedIndexChanged += comboBoxSauces_SelectedIndexChanged;
            textBoxTacoName.TextChanged += (sender, e) => currentTaco.Name = textBoxTacoName.Text;
        }

        private void LoadProducts()
        {
            LoadTortillas();
            LoadIngredients();
            LoadSauces();
            UpdateTotalPrice();
        }

        private void LoadTortillas()
        {
            var tortillas = productController.GetAllTortillas();
            checkedListBoxTortillas.DataSource = new BindingList<Tortilla>(tortillas);
            checkedListBoxTortillas.DisplayMember = "Name";
            checkedListBoxTortillas.ValueMember = "Id";
        }

        private void LoadIngredients()
        {
            var ingredients = productController.GetAllIngredients();
            checkedListBoxIngredients.DataSource = new BindingList<Ingredient>(ingredients);
            checkedListBoxIngredients.DisplayMember = "Name";
            checkedListBoxIngredients.ValueMember = "Id";
        }

        private void LoadSauces()
        {
            var sauces = productController.GetAllSauces();
            comboBoxSauces.DataSource = new BindingList<Sauce>(sauces);
            comboBoxSauces.DisplayMember = "Name";
            comboBoxSauces.ValueMember = "SauceId";
        }

        private void SetupDataGridView()
        {
            dgvSelectedItems.DataSource = new BindingList<Taco.SelectedItemView>();

            dgvSelectedItems.Columns.Clear();
            dgvSelectedItems.AutoGenerateColumns = false;

            dgvSelectedItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Categoría",
                DataPropertyName = "Category",
                ReadOnly = true
            });

            dgvSelectedItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                ReadOnly = true
            });

            dgvSelectedItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Precio",
                DataPropertyName = "Price",
                ReadOnly = true
            });

            dgvSelectedItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateSelectedItemsGrid();
        }

        private void UpdateSelectedItemsGrid()
        {
            dgvSelectedItems.DataSource = new BindingList<Taco.SelectedItemView>(currentTaco.GetSelectedItemViews());
        }

        private void checkedListBoxTortillas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var tortilla = (Tortilla)checkedListBoxTortillas.Items[e.Index];
                if (e.NewValue == CheckState.Checked)
                {
                    try
                    {
                        currentTaco.AddTortillas(new List<Tortilla> { tortilla });
                    }
                    catch (ArgumentException ex)
                    {
                        e.NewValue = CheckState.Unchecked;
                        MessageBox.Show(ex.Message, "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    currentTaco.AddTortillas(currentTaco.Tortillas.Where(t => t.Id != tortilla.Id).ToList());
                }
                UpdateTotalPrice();
                UpdateSelectedItemsGrid();
            }));
        }

        private void checkedListBoxIngredients_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var ingredient = (Ingredient)checkedListBoxIngredients.Items[e.Index];
                if (e.NewValue == CheckState.Checked)
                {
                    try
                    {
                        currentTaco.AddIngredients(new List<Ingredient> { ingredient });
                    }
                    catch (ArgumentException ex)
                    {
                        e.NewValue = CheckState.Unchecked;
                        MessageBox.Show(ex.Message, "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    currentTaco.AddIngredients(currentTaco.Ingredients.Where(i => i.Id != ingredient.Id).ToList());
                }
                UpdateTotalPrice();
                UpdateSelectedItemsGrid();
            }));
        }

        private void comboBoxSauces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSauces.SelectedItem is Sauce selectedSauce)
            {
                currentTaco.SetSauce(selectedSauce);
                UpdateTotalPrice();
                UpdateSelectedItemsGrid();
            }
        }

        private void UpdateTotalPrice()
        {
            labelTotalPriceValue.Text = $"${currentTaco.TotalPrice:F2}";
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            if (currentTaco.Tortillas.Count == 0 || currentTaco.Ingredients.Count == 0)
            {
                MessageBox.Show("Debes seleccionar al menos una tortilla y un ingrediente.", "Orden incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                currentTaco.CreatedAt = DateTime.Now;
                int tacoId = tacoController.CreateTaco(currentTaco);
                MessageBox.Show($"Taco '{currentTaco.Name}' ordenado con éxito. ID del pedido: {tacoId}", "Orden completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la orden: debe ingresar el nombre del Taco {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            currentTaco = new Taco();
            currentTaco.Name = "Taco Personalizado";

            for (int i = 0; i < checkedListBoxTortillas.Items.Count; i++)
            {
                checkedListBoxTortillas.SetItemChecked(i, false);
            }

            for (int i = 0; i < checkedListBoxIngredients.Items.Count; i++)
            {
                checkedListBoxIngredients.SetItemChecked(i, false);
            }

            comboBoxSauces.SelectedIndex = -1;
            UpdateSelectedItemsGrid();
            UpdateTotalPrice();

            // Reset the taco name TextBox
            var textBoxTacoName = this.Controls.OfType<TextBox>().FirstOrDefault(c => c.Location.Y == 550);
            if (textBoxTacoName != null)
            {
                textBoxTacoName.Text = "Taco Personalizado";
            }
        }
    }
}

