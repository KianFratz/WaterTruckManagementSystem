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
    public partial class CustomerControl4 : UserControl
    {
        public CustomerControl4()
        {
            InitializeComponent();
        }
        private void LoadOrders()
        {
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            string query = @"SELECT
                                ArchivedOrders.OrderID,
                                ArchivedOrders.Item,
                                ArchivedOrders.Price,
                                ArchivedOrders.Quantity,
                                ArchivedOrders.TotalPrice,
                                ArchivedOrders.OrderDate,
                                ArchivedOrders.DeliveryDate,
                                ArchivedOrders.Status,
                                ArchivedOrders.ModeOfPayment
                            FROM
                                ArchivedOrders
                            WHERE
                                CustomerID = @CustomerID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", Session.CustomerID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable ordersTable = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(ordersTable);

                    // Debugging: Check if data is retrieved
                    if (ordersTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No orders found for the customer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Bind to DataGridView
                    dgvOrders.DataSource = ordersTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SearchOrders(string searchText)
        {
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";
            string query = @"
                    SELECT
                        ArchivedOrders.OrderID,
                        ArchivedOrders.Item,
                        ArchivedOrders.Price,
                        ArchivedOrders.Quantity,
                        ArchivedOrders.TotalPrice,
                        ArchivedOrders.OrderDate,
                        ArchivedOrders.DeliveryDate,
                        ArchivedOrders.Status,
                        ArchivedOrders.ModeOfPayment
                    FROM 
                        ArchivedOrders
                    WHERE CustomerID = @CustomerID
                        AND (
                            OrderID LIKE @SearchText OR
                            Item LIKE @SearchText OR
                            Status LIKE @SearchText
                        );";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", Session.CustomerID);
                    cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable ordersTable = new DataTable();

                    try
                    {
                        conn.Open();
                        adapter.Fill(ordersTable);

                        // Bind the filtered data to the DataGridView
                        dgvOrders.DataSource = ordersTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            LoadOrders();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchOrders(txtSearch.Text); 
        }
    }
}
