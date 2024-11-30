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
    public partial class CustomerControl3 : UserControl
    {
        
        public CustomerControl3()
        {
            InitializeComponent();
            
            
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //LoadOrders();

        }
        // Populate Data grid view
        private void LoadOrders()
        {
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            string query = @"SELECT
                                Orders.OrderID,
                                Orders.Item,
                                Orders.Price,
                                Orders.Quantity,
                                Orders.TotalPrice,
                                Orders.OrderDate,
                                Orders.DeliveryDate,
                                Orders.Status,
                                Orders.ModeOfPayment
                            FROM
                                Orders
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            // Prices for items
            var prices = new Dictionary<string, double>
            {
                { "Gallon", 10 },
                { "Tank", 500 },
                { "Barrel", 60 }
            };

            if (cmbItem.SelectedItem != null)
            {
                string selectedItem = cmbItem.SelectedItem.ToString();

                if (prices.ContainsKey(selectedItem))
                {
                    // Get the price based on the selected item
                    double itemPrice = prices[selectedItem];


                    // Calculate the total price
                    if (int.TryParse(txtQuantity.Text, out int quantity))
                    {
                        double totalPrice = itemPrice * quantity;
                        txtTotalPrice.Text = totalPrice.ToString("F2"); // Format to 2 decimal places
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No item selected. Please choose an item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // edit button
        private void button1_Click(object sender, EventArgs e)
        {
            // Validate the selected row in DataGridView
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the OrderID from the selected row
            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            // Get updated values from ComboBox and TextBoxes
            string updatedItem = cmbItem.SelectedItem?.ToString(); // Get selected item from ComboBox

            if (string.IsNullOrEmpty(updatedItem))
            {
                MessageBox.Show("Please select a valid item from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int updatedQuantity;
            double updatedTotalPrice;

            // Validate and retrieve quantity and total price
            if (!int.TryParse(txtQuantity.Text, out updatedQuantity) || updatedQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtTotalPrice.Text, out updatedTotalPrice) || updatedTotalPrice <= 0)
            {
                MessageBox.Show("Please enter a valid total price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve delivery date
            DateTime updatedDeliveryDate = dtpDeliveryDate.Value;


            // Database connection string
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            // SQL query to update the order
            string query = @"UPDATE Orders
                     SET Item = @Item, 
                         Quantity = @Quantity, 
                         TotalPrice = @TotalPrice, 
                         DeliveryDate = @DeliveryDate
                     WHERE OrderID = @OrderID";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@Item", updatedItem);
                    cmd.Parameters.AddWithValue("@Quantity", updatedQuantity);
                    cmd.Parameters.AddWithValue("@TotalPrice", updatedTotalPrice);
                    cmd.Parameters.AddWithValue("@DeliveryDate", updatedDeliveryDate);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView
                            LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Auto-Resize Columns
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ensure the click is not on the header row
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvOrders.Rows[e.RowIndex];

                try
                {
                    // Access values from the row by column index or column name
                    cmbItem.Text = selectedRow.Cells["Item"].Value.ToString();
                    txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                    txtTotalPrice.Text = selectedRow.Cells["TotalPrice"].Value.ToString();
                    dtpDeliveryDate.Value = Convert.ToDateTime(selectedRow.Cells["DeliveryDate"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the OrderID of the selected row
            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            // Confirm deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            // Database connection string
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            // SQL query to delete order
            string query = @"DELETE FROM Orders WHERE OrderID = @OrderID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the parameter for OrderID
                    cmd.Parameters.AddWithValue(@"OrderID", orderId);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView
                            LoadOrders();
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void CustomerControl3_Load(object sender, EventArgs e)
        {
            //LoadOrders();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to received order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the OrderID from the selected row
            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            // Get the Status of the selected row
            string orderStatus = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

            // Check if the order status is "Delivering"
            if (orderStatus != "Delivering")
            {
                MessageBox.Show("Only orders with the status 'Delivering' can be received.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm action with the user
            DialogResult result = MessageBox.Show("Are you sure you want to mark this order as received?", "Confirm Received", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }


            // Database connection string
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";

            // SQL query to update the status 
            string query = @"UPDATE Orders SET Status = @NewStatus WHERE OrderID = @OrderID";

            // insert query
            string archiveQuery = @"
                            INSERT INTO 
                                ArchivedOrders (OrderID, CustomerID, Item, Price, Quantity, TotalPrice, OrderDate, DeliveryDate, Status, ModeOfPayment)
                            SELECT 
                                OrderID, CustomerID, Item, Price, Quantity, TotalPrice, OrderDate, DeliveryDate, Status, ModeOfPayment
                            FROM 
                                Orders
                            WHERE 
                                OrderID = @OrderID;
                        ";

            // delete query
            string deleteQuery = "DELETE FROM Orders WHERE OrderID = @OrderID;";

            // update status
            string updateStatusQuery = "UPDATE Orders SET Status = @NewStatus WHERE OrderID = @OrderID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, conn))
                using (SqlCommand archiveCmd = new SqlCommand(archiveQuery, conn))
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    // Add parameters for all commands
                    updateCmd.Parameters.AddWithValue("@OrderID", orderId);
                    updateCmd.Parameters.AddWithValue("@NewStatus", "Received");

                    archiveCmd.Parameters.AddWithValue("@OrderID", orderId);
                    deleteCmd.Parameters.AddWithValue("@OrderID", orderId);

                    try
                    {
                        conn.Open();

                        // Start a transaction
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            updateCmd.Transaction = transaction;
                            archiveCmd.Transaction = transaction;
                            deleteCmd.Transaction = transaction;

                            // Update the status to "Received"
                            int rowsUpdated = updateCmd.ExecuteNonQuery();
                            if (rowsUpdated == 0)
                            {
                                throw new Exception("Failed to update the order status.");
                            }

                            // Archive the order
                            int rowsArchived = archiveCmd.ExecuteNonQuery();
                            if (rowsArchived == 0)
                            {
                                throw new Exception("Failed to archive the order.");
                            }

                            // Delete the order from the Orders table
                            int rowsDeleted = deleteCmd.ExecuteNonQuery();
                            if (rowsDeleted == 0)
                            {
                                throw new Exception("Failed to delete the order after archiving.");
                            }

                            // Commit the transaction
                            transaction.Commit();
                            MessageBox.Show("Order marked as received and archived successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView
                            LoadOrders();
                        }
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

        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            // Perform the search
            SearchOrders(searchText);
        }

        // Search method
        private void SearchOrders(string searchText)
        {
            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";
            string query = @"
                    SELECT
                        Orders.OrderID,
                        Orders.Item,
                        Orders.Price,
                        Orders.Quantity,
                        Orders.TotalPrice,
                        Orders.OrderDate,
                        Orders.DeliveryDate,
                        Orders.Status,
                        Orders.ModeOfPayment
                    FROM Orders
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
    }
}
    