namespace TacotitosFoodTruck.Views
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.CheckedListBox checkedListBoxTortillas;
        private System.Windows.Forms.CheckedListBox checkedListBoxIngredients;
        private System.Windows.Forms.ComboBox comboBoxSauces;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.DataGridView dgvSelectedItems;
        private System.Windows.Forms.Label labelTortillas;
        private System.Windows.Forms.Label labelIngredients;
        private System.Windows.Forms.Label labelSauces;
        private System.Windows.Forms.Label labelSelectedItems;
        private System.Windows.Forms.TextBox textBoxTacoName;
        private System.Windows.Forms.Label labelTotalPriceValue;

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
            this.checkedListBoxTortillas = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxIngredients = new System.Windows.Forms.CheckedListBox();
            this.comboBoxSauces = new System.Windows.Forms.ComboBox();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.dgvSelectedItems = new System.Windows.Forms.DataGridView();
            this.labelTortillas = new System.Windows.Forms.Label();
            this.labelIngredients = new System.Windows.Forms.Label();
            this.labelSauces = new System.Windows.Forms.Label();
            this.labelSelectedItems = new System.Windows.Forms.Label();
            this.textBoxTacoName = new System.Windows.Forms.TextBox();
            this.labelTotalPriceValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedItems)).BeginInit();
            this.SuspendLayout();

            // checkedListBoxTortillas
            this.checkedListBoxTortillas.FormattingEnabled = true;
            this.checkedListBoxTortillas.Location = new System.Drawing.Point(12, 32);
            this.checkedListBoxTortillas.Name = "checkedListBoxTortillas";
            this.checkedListBoxTortillas.Size = new System.Drawing.Size(200, 150);
            this.checkedListBoxTortillas.TabIndex = 0;

            // checkedListBoxIngredients
            this.checkedListBoxIngredients.FormattingEnabled = true;
            this.checkedListBoxIngredients.Location = new System.Drawing.Point(12, 208);
            this.checkedListBoxIngredients.Name = "checkedListBoxIngredients";
            this.checkedListBoxIngredients.Size = new System.Drawing.Size(200, 150);
            this.checkedListBoxIngredients.TabIndex = 1;

            // comboBoxSauces
            this.comboBoxSauces.FormattingEnabled = true;
            this.comboBoxSauces.Location = new System.Drawing.Point(12, 384);
            this.comboBoxSauces.Name = "comboBoxSauces";
            this.comboBoxSauces.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSauces.TabIndex = 2;

            // textBoxTacoName
            this.textBoxTacoName.Location = new System.Drawing.Point(12, 450);
            this.textBoxTacoName.Name = "textBoxTacoName";
            this.textBoxTacoName.Size = new System.Drawing.Size(200, 20);
            this.textBoxTacoName.TabIndex = 10;
            this.textBoxTacoName.Text = "Taco Personalizado";

            // labelTotalPrice
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(12, 480);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(76, 13);
            this.labelTotalPrice.TabIndex = 3;
            this.labelTotalPrice.Text = "Precio Total:";

            // labelTotalPriceValue
            this.labelTotalPriceValue.AutoSize = true;
            this.labelTotalPriceValue.Location = new System.Drawing.Point(12, 500);
            this.labelTotalPriceValue.Name = "labelTotalPriceValue";
            this.labelTotalPriceValue.Size = new System.Drawing.Size(76, 13);
            this.labelTotalPriceValue.TabIndex = 11;
            this.labelTotalPriceValue.Text = "$0.00";
            this.labelTotalPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // buttonOrder
            this.buttonOrder.Location = new System.Drawing.Point(12, 530);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(200, 30);
            this.buttonOrder.TabIndex = 4;
            this.buttonOrder.Text = "Ordenar Taco";
            this.buttonOrder.UseVisualStyleBackColor = true;
            this.buttonOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);

            // dgvSelectedItems
            this.dgvSelectedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedItems.Location = new System.Drawing.Point(230, 32);
            this.dgvSelectedItems.Name = "dgvSelectedItems";
            this.dgvSelectedItems.Size = new System.Drawing.Size(550, 530);
            this.dgvSelectedItems.TabIndex = 5;
            this.dgvSelectedItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            // labelTortillas
            this.labelTortillas.AutoSize = true;
            this.labelTortillas.Location = new System.Drawing.Point(12, 16);
            this.labelTortillas.Name = "labelTortillas";
            this.labelTortillas.Size = new System.Drawing.Size(46, 13);
            this.labelTortillas.TabIndex = 6;
            this.labelTortillas.Text = "Tortillas:";

            // labelIngredients
            this.labelIngredients.AutoSize = true;
            this.labelIngredients.Location = new System.Drawing.Point(12, 192);
            this.labelIngredients.Name = "labelIngredients";
            this.labelIngredients.Size = new System.Drawing.Size(68, 13);
            this.labelIngredients.TabIndex = 7;
            this.labelIngredients.Text = "Ingredientes:";

            // labelSauces
            this.labelSauces.AutoSize = true;
            this.labelSauces.Location = new System.Drawing.Point(12, 368);
            this.labelSauces.Name = "labelSauces";
            this.labelSauces.Size = new System.Drawing.Size(43, 13);
            this.labelSauces.TabIndex = 8;
            this.labelSauces.Text = "Salsas:";

            // labelSelectedItems
            this.labelSelectedItems.AutoSize = true;
            this.labelSelectedItems.Location = new System.Drawing.Point(230, 16);
            this.labelSelectedItems.Name = "labelSelectedItems";
            this.labelSelectedItems.Size = new System.Drawing.Size(115, 13);
            this.labelSelectedItems.TabIndex = 9;
            this.labelSelectedItems.Text = "Elementos Seleccionados:";

            // ClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.labelTotalPriceValue);
            this.Controls.Add(this.textBoxTacoName);
            this.Controls.Add(this.labelSelectedItems);
            this.Controls.Add(this.labelSauces);
            this.Controls.Add(this.labelIngredients);
            this.Controls.Add(this.dgvSelectedItems);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.comboBoxSauces);
            this.Controls.Add(this.checkedListBoxIngredients);
            this.Controls.Add(this.checkedListBoxTortillas);
            this.Name = "ClientForm";
            this.Text = "Tacotitos Food Truck - Ordenar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}

