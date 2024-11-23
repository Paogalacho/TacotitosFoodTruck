using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TacotitosFoodTruck.Controllers;
using TacotitosFoodTruck.Data;

namespace TacotitosFoodTruck.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TestDatabaseConnection(); // Verifica conexión al iniciar
        }

        private void TestDatabaseConnection()
        {
            try
            {
                var dbConnection = DatabaseConnection.GetInstance();
                using (var connection = dbConnection.Connect()) // Abrir y cerrar automáticamente
                {
                    lblConnectionStatus.ForeColor = Color.Green;
                    lblConnectionStatus.Text = "Database connected successfully!";
                }
            }
            catch (Exception ex)
            {
                lblConnectionStatus.ForeColor = Color.Red;
                lblConnectionStatus.Text = "Database connection failed: " + ex.Message;
            }

            lblConnectionStatus.Visible = true;
        }


        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
        }
    }
}
