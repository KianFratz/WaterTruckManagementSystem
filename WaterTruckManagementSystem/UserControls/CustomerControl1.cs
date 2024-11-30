using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterTruckManagementSystem.UserControls
{
    public partial class CustomerControl1 : UserControl
    {
        public CustomerControl1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblOrder_Click(object sender, EventArgs e)
        {
            
        }
        private int GetTotalOrdersCount(int customerId)
        {
            int totalOrders = 0;

            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            string query = @"SELECT COUNT(*) AS TotalOrders
                     FROM Orders
                     WHERE CustomerID = @CustomerID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

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
            int customerId = Session.CustomerID;
            int totalOrders = GetTotalOrdersCount(customerId);

            lblOrder.Text = totalOrders.ToString();
        }
    }
}
