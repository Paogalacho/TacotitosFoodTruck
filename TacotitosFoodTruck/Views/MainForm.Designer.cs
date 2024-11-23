namespace TacotitosFoodTruck.Views
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnAdmin;
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblConnectionStatus
             
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(12, 9);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(0, 13); // Inicia vacío
            this.lblConnectionStatus.TabIndex = 0;
            this.lblConnectionStatus.Visible = false; // Oculto por defecto

            // btnClient
            this.btnClient.Location = new System.Drawing.Point(50, 50);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(100, 30);
            this.btnClient.TabIndex = 0;
            this.btnClient.Text = "Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);

            // btnAdmin
            this.btnAdmin.Location = new System.Drawing.Point(50, 100);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 30);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnClient);
            this.Name = "MainForm";
            this.Text = "Tacotitos Food Truck";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        

        #endregion
    }
}
