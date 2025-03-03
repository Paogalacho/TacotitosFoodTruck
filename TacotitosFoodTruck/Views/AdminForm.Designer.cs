namespace TacotitosFoodTruck.Views
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes de la interfaz
        private GroupBox groupBoxIngredients;
        private DataGridView dgvIngredients;
        private Button btnAddIngredient;
        private Button btnEditIngredient;
        private Button btnDeleteIngredient;
        private Button btnAddTortilla;
        private Button btnEditTortilla;
        private Button btnDeleteTortilla;
        private DataGridView dgvTortillas;
        private GroupBox groupBoxTortillas;
        private GroupBox groupBoxTacos;
        private DataGridView dgvTacos;
        private Button btnCheapestTaco;
        private Button btnMostExpensiveTaco;
        private Button btnAveragePrice;
        private DataGridView dgvSalsas;
        private Button btnAddSalsa;
        private Button btnEditSalsa;
        private Button btnDeleteSalsa;
        private GroupBox groupBoxSalsas;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            this.groupBoxIngredients = new System.Windows.Forms.GroupBox();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.btnEditIngredient = new System.Windows.Forms.Button();
            this.btnDeleteIngredient = new System.Windows.Forms.Button();
            this.groupBoxTortillas = new System.Windows.Forms.GroupBox();
            this.dgvTortillas = new System.Windows.Forms.DataGridView();
            this.btnAddTortilla = new System.Windows.Forms.Button();
            this.btnEditTortilla = new System.Windows.Forms.Button();
            this.btnDeleteTortilla = new System.Windows.Forms.Button();
            this.groupBoxTacos = new System.Windows.Forms.GroupBox();
            this.dgvTacos = new System.Windows.Forms.DataGridView();
            this.groupBoxSalsas = new System.Windows.Forms.GroupBox();
            this.dgvSalsas = new System.Windows.Forms.DataGridView();
            this.btnAddSalsa = new System.Windows.Forms.Button();
            this.btnEditSalsa = new System.Windows.Forms.Button();
            this.btnDeleteSalsa = new System.Windows.Forms.Button();
            this.Controls.Add(this.groupBoxTacos);
            this.Controls.Add(this.groupBoxIngredients);
            this.Controls.Add(this.groupBoxTortillas);
            this.Controls.Add(this.groupBoxSalsas);


            // Configuración del formulario
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1366, 720);
            this.Text = "Admin - Tacotitos Food Truck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;

            // Configuración del GroupBox para ingredientes
            this.groupBoxIngredients.Text = "Ingredients";
            this.groupBoxIngredients.Location = new System.Drawing.Point(20, 20);
            this.groupBoxIngredients.Size = new System.Drawing.Size(560, 220);
            this.groupBoxIngredients.Controls.Add(this.dgvIngredients);
            this.groupBoxIngredients.Controls.Add(this.btnAddIngredient);
            this.groupBoxIngredients.Controls.Add(this.btnEditIngredient);
            this.groupBoxIngredients.Controls.Add(this.btnDeleteIngredient);

            // DataGridView para listar los ingredientes
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Location = new System.Drawing.Point(10, 30);
            this.dgvIngredients.Size = new System.Drawing.Size(460, 200);
            this.dgvIngredients.Name = "dgvIngredients";

            // Botón "Agregar Ingrediente"
            this.btnAddIngredient.Text = "Add Ingredient";
            this.btnAddIngredient.Location = new System.Drawing.Point(480, 30);
            this.btnAddIngredient.Size = new System.Drawing.Size(70, 30);
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);

            // Botón "Editar Ingrediente"
            this.btnEditIngredient.Text = "Edit Ingredient";
            this.btnEditIngredient.Location = new System.Drawing.Point(480, 70);
            this.btnEditIngredient.Size = new System.Drawing.Size(70, 30);
            this.btnEditIngredient.Click += new System.EventHandler(this.btnEditIngredient_Click);

            // Botón "Eliminar Ingrediente"
            this.btnDeleteIngredient.Text = "Delete Ingredient";
            this.btnDeleteIngredient.Location = new System.Drawing.Point(480, 110);
            this.btnDeleteIngredient.Size = new System.Drawing.Size(70, 30);
            this.btnDeleteIngredient.Click += new System.EventHandler(this.btnDeleteIngredient_Click);

            // Agregar GroupBox para Tortillas
            this.groupBoxTortillas.Text = "Tortillas";
            this.groupBoxTortillas.Location = new System.Drawing.Point(20, 260);
            this.groupBoxTortillas.Size = new System.Drawing.Size(560, 220);
            this.groupBoxTortillas.Controls.Add(this.dgvTortillas);
            this.groupBoxTortillas.Controls.Add(this.btnAddTortilla);
            this.groupBoxTortillas.Controls.Add(this.btnEditTortilla);
            this.groupBoxTortillas.Controls.Add(this.btnDeleteTortilla);
            
            // DataGridView para listar las tortillas
            this.dgvTortillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTortillas.Location = new System.Drawing.Point(10, 30);
            this.dgvTortillas.Name = "dgvTortillas";
            this.dgvTortillas.Size = new System.Drawing.Size(460, 200);

            // Botón "Agregar Tortilla"
            this.btnAddTortilla.Text = "Add Tortilla";
            this.btnAddTortilla.Location = new System.Drawing.Point(480, 30);
            this.btnAddTortilla.Size = new System.Drawing.Size(70, 30);
            this.btnAddTortilla.Click += new System.EventHandler(this.btnAddTortilla_Click);

            // Botón "Editar Tortilla"
            this.btnEditTortilla.Text = "Edit Tortilla";
            this.btnEditTortilla.Location = new System.Drawing.Point(480, 70);
            this.btnEditTortilla.Size = new System.Drawing.Size(70, 30);
            this.btnEditTortilla.Click += new System.EventHandler(this.btnEditTortilla_Click);

            // Botón "Eliminar Tortilla"
            this.btnDeleteTortilla.Text = "Delete Tortilla";
            this.btnDeleteTortilla.Location = new System.Drawing.Point(480, 110);
            this.btnDeleteTortilla.Size = new System.Drawing.Size(70, 30);
            this.btnDeleteTortilla.Click += new System.EventHandler(this.btnDeleteTortilla_Click);

            // GroupBox para tacos
            this.groupBoxTacos.Text = "Tacos";
            this.groupBoxTacos.Location = new System.Drawing.Point(600, 20);
            this.groupBoxTacos.Size = new System.Drawing.Size(560, 700);
            this.groupBoxTacos.Controls.Add(this.dgvTacos);
            this.groupBoxTacos.Controls.Add(this.btnCheapestTaco);
            this.groupBoxTacos.Controls.Add(this.btnMostExpensiveTaco);
            this.groupBoxTacos.Controls.Add(this.btnAveragePrice);
            
            // DataGridView para listar tacos
            this.dgvTacos.Location = new System.Drawing.Point(10, 30);
            this.dgvTacos.Size = new System.Drawing.Size(520, 250);
            this.dgvTacos.ReadOnly = true;
            this.dgvTacos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTacos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTacos.AllowUserToAddRows = false;
            this.dgvTacos.AllowUserToDeleteRows = false;

            // Botón para obtener el taco más económico
            this.btnCheapestTaco = new System.Windows.Forms.Button();
            this.btnCheapestTaco.Text = "Taco más Económico";
            this.btnCheapestTaco.Location = new System.Drawing.Point(10, 300);
            this.btnCheapestTaco.Size = new System.Drawing.Size(130, 30);
            this.btnCheapestTaco.Click += new System.EventHandler(this.btnCheapestTaco_Click);

            // Botón para obtener el taco más caro
            this.btnMostExpensiveTaco = new System.Windows.Forms.Button();
            this.btnMostExpensiveTaco.Text = "Taco más Costoso";
            this.btnMostExpensiveTaco.Location = new System.Drawing.Point(160, 300);
            this.btnMostExpensiveTaco.Size = new System.Drawing.Size(130, 30);
            this.btnMostExpensiveTaco.Click += new System.EventHandler(this.btnMostExpensiveTaco_Click);

            // Botón para calcular el precio promedio
            this.btnAveragePrice = new System.Windows.Forms.Button();
            this.btnAveragePrice.Text = "Precio Promedio";
            this.btnAveragePrice.Location = new System.Drawing.Point(310, 300);
            this.btnAveragePrice.Size = new System.Drawing.Size(130, 30);
            this.btnAveragePrice.Click += new System.EventHandler(this.btnAverageTacoPrice_Click);

            // Agrega los controles al GroupBox
            this.groupBoxTacos.Controls.Add(this.dgvTacos);
            this.groupBoxTacos.Controls.Add(this.btnCheapestTaco);
            this.groupBoxTacos.Controls.Add(this.btnMostExpensiveTaco);
            this.groupBoxTacos.Controls.Add(this.btnAveragePrice);

            // groupBoxSalsas
            this.groupBoxSalsas.Location = new System.Drawing.Point(20, 500);
            this.groupBoxSalsas.Name = "groupBoxSalsas";
            this.groupBoxSalsas.Size = new System.Drawing.Size(560, 220);
            this.groupBoxSalsas.TabIndex = 6;
            this.groupBoxSalsas.TabStop = false;
            this.groupBoxSalsas.Text = "Sauces";
            this.groupBoxSalsas.Controls.Add(this.btnAddSalsa);
            this.groupBoxSalsas.Controls.Add(this.btnEditSalsa);
            this.groupBoxSalsas.Controls.Add(this.btnDeleteSalsa);
            this.groupBoxSalsas.Controls.Add(this.dgvSalsas);

            // dgvSalsas
            this.dgvSalsas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalsas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalsas.Location = new System.Drawing.Point(10, 30);
            this.dgvSalsas.Name = "dgvSalsas";
            this.dgvSalsas.Size = new System.Drawing.Size(460, 150);
            this.dgvSalsas.TabIndex = 1;

            // btnAddSalsa
            this.btnAddSalsa.Location = new System.Drawing.Point(480, 30);
            this.btnAddSalsa.Name = "btnAddSalsa";
            this.btnAddSalsa.Size = new System.Drawing.Size(70, 30);
            this.btnAddSalsa.TabIndex = 6;
            this.btnAddSalsa.Text = "Add Sauce";
            this.btnAddSalsa.UseVisualStyleBackColor = true;
            this.btnAddSalsa.Click += new System.EventHandler(this.btnAddSalsa_Click);

            // btnEditSalsa
            this.btnEditSalsa.Location = new System.Drawing.Point(480, 70);
            this.btnEditSalsa.Name = "btnEditSalsa";
            this.btnEditSalsa.Size = new System.Drawing.Size(70, 30);
            this.btnEditSalsa.TabIndex = 7;
            this.btnEditSalsa.Text = "Edit   Sauce";
            this.btnEditSalsa.UseVisualStyleBackColor = true;
            this.btnEditSalsa.Click += new System.EventHandler(this.btnEditSalsa_Click);

            // btnDeleteSalsa
            this.btnDeleteSalsa.Location = new System.Drawing.Point(480, 110);
            this.btnDeleteSalsa.Name = "btnDeleteSalsa";
            this.btnDeleteSalsa.Size = new System.Drawing.Size(70, 30);
            this.btnDeleteSalsa.TabIndex = 8;
            this.btnDeleteSalsa.Text = "Delete Sauce";
            this.btnDeleteSalsa.UseVisualStyleBackColor = true;
            this.btnDeleteSalsa.Click += new System.EventHandler(this.btnDeleteSalsa_Click);
            


            this.ResumeLayout(false);
        }
    }
}

