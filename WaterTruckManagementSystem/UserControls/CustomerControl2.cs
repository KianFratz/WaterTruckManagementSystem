using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace WaterTruckManagementSystem.UserControls
{
    public partial class CustomerControl2 : UserControl
    {
        CustomerControl3 customerControl3;

        string gallon = "Gallon";
        string tank = "Tank";
        string barrel = "Barrel";

        double gallonPrice = 10;
        double tankPrice = 500;
        double barrelPrice = 60;


        public CustomerControl2()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtItem.Text = gallon;
            txtItemPrice.Text = gallonPrice.ToString();
            
        }

        private void dgvOrderInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtItem.Text = tank;
            txtItemPrice.Text = tankPrice.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtItem.Text = barrel;
            txtItemPrice.Text = barrelPrice.ToString();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            // Check if txtQuantity is not empty and contains a valid number
            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity))
            {
                txtTotalPrice.Clear(); // Clear total price if input is invalid
                return;
            }

            // Define a dictionary to map item names to their respective prices
            var itemPrices = new Dictionary<string, double>
            {
                { "Gallon", gallonPrice },
                { "Tank", tankPrice },
                { "Barrel", barrelPrice }
            };

            // Check if the selected item exists in the dictionary
            if (itemPrices.TryGetValue(txtItem.Text, out double pricePerUnit))
            {
                double totalPrice = pricePerUnit * quantity;
                txtTotalPrice.Text = totalPrice.ToString("F2"); // Format to 2 decimal places
            }
            else
            {
                txtTotalPrice.Clear(); // Clear total price if item is invalid
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void btnPay_Click(object sender, EventArgs e)
        {
            int customerId = Session.CustomerID;
            string item = txtItem.Text;
            double price = double.Parse(txtItemPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            double totalPrice = double.Parse(txtTotalPrice.Text);
            DateTime deliveryDate = dtpDeliveryDate.Value;

            // SQL Connection String
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            // SQL Insert Command
            string query = @"INSERT INTO Orders (CustomerID, Item, Price, Quantity, TotalPrice, DeliveryDate)
                     VALUES (@CustomerID, @Item, @Price, @Quantity, @TotalPrice, @DeliveryDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@Item", item);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@DeliveryDate", deliveryDate);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Order successfully submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        


    }
}
