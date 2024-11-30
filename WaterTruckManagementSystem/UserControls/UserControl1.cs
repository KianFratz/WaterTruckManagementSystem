using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WaterTruckManagementSystem.userController
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private int GetTotalEarnings()
        {
            int totalEarnings = 0;

            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            // SQL query to sum the TotalPrice column
            string query = @"SELECT SUM(TotalPrice) AS TotalEarnings FROM Orders";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        // If result is not null, parse it to a decimal
                        if (result != null && result != DBNull.Value)
                        {
                            totalEarnings = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return totalEarnings;
        }
        private int GetTotalOrdersCount()
        {
            int totalOrders = 0;

            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            // SQL query to count all orders
            string query = @"SELECT COUNT(*) AS TotalOrders FROM Orders";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        // If result is not null, parse it to an integer
                        if (result != null && result != DBNull.Value)
                        {
                            totalOrders = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return totalOrders;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
            int totalOrders = GetTotalOrdersCount();

            lblTotalOrders.Text = totalOrders.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int getTotalEarnings = GetTotalEarnings();

            lblTotalEarnings.Text = getTotalEarnings.ToString();
        }
    }
}
