namespace TacotitosFoodTruck.Views
{
    partial class MainForm
    {
        
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnAdmin;


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
            lblConnectionStatus = new Label();
            btnClient = new Button();
            btnAdmin = new Button();

            SuspendLayout();
      
            // lblConnectionStatus
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Location = new Point(14, 10);
            lblConnectionStatus.Margin = new Padding(4, 0, 4, 0);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(0, 15);
            lblConnectionStatus.TabIndex = 0;
            lblConnectionStatus.Visible = false;
            
            // btnClient
            btnClient.Location = new Point(1070, 339);
            btnClient.Margin = new Padding(4, 3, 4, 3);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(200, 200);
            btnClient.TabIndex = 0;
            btnClient.Text = ""; // Sin texto, solo imagen
            btnClient.Image = Image.FromFile("Images/ClientImage.png");
            btnClient.FlatStyle = FlatStyle.Flat;
            btnClient.FlatAppearance.BorderSize = 0;
            btnClient.UseVisualStyleBackColor = true;
            btnClient.ImageAlign = ContentAlignment.MiddleCenter;
            btnClient.Image = new Bitmap(Image.FromFile("Images/ClientImage.png"), new Size(200, 200));
            btnClient.Click += btnClient_Click;
             
            // btnAdmin 
            btnAdmin.Location = new Point(110, 339);
            btnAdmin.Margin = new Padding(4, 3, 4, 3);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(200, 200); 
            btnAdmin.TabIndex = 1;
            btnAdmin.Text = ""; // Sin texto, solo imagen
            btnAdmin.Image = Image.FromFile("Images/AdminImage.png");
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.ImageAlign = ContentAlignment.MiddleCenter;
            btnAdmin.Image = new Bitmap(Image.FromFile("Images/AdminImage.png"), new Size(200, 200)); 
            btnAdmin.Click += btnAdmin_Click;
             
            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1366, 720);
            Controls.Add(lblConnectionStatus);
            Controls.Add(btnClient);
            Controls.Add(btnAdmin);
            BackgroundImage = Image.FromFile("Images/Tacotitos-Logo (1).png");
            BackgroundImageLayout = ImageLayout.Center;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tacotitos Food Truck";
            Icon = new Icon("Images/Tacotitos-Favicon.ico");

            ResumeLayout(false);
            PerformLayout();

        }


    }

}
