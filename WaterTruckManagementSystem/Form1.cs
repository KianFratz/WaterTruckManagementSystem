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
using System.Security.Cryptography;

namespace WaterTruckManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;");
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            
            txtUsername.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get input from form fields
            string username = txtUsername.Text.Trim().ToLower();
            string password = txtPassword.Text.ToLower();

            // Check if fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Authenticate user and get their role
            string role = AuthenticateUserAndGetRole(username, password);

            if (role != null)
            {
                // Session
                Session.Username = username;
                Session.CustomerID = GetCustomerID(username); // Optional if needed

                if (role == "Admin")
                {
                    MessageBox.Show("Welcome Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dashboard adminDashboard = new Dashboard();
                    adminDashboard.Show();
                }
                else if (role == "Customer")
                {
                    MessageBox.Show("Welcome Customer!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerDashboard customerDashboard = new CustomerDashboard();
                    customerDashboard.Show();
                }

                // Hide login form
                this.Hide();
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid Username or Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Get user ID
        private int GetCustomerID(string username)
        {
            int customerId = -1; // Default value if not found
            string query = "SELECT CustomerID FROM Customers WHERE Username = @Username";

            string connectionString = @"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            customerId = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error retrieving CustomerID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return customerId;
        }

        // AuthenticateUserAndGetRole Function
        private string AuthenticateUserAndGetRole(string username, string password)
        {
            string role = null;

            // check the Customers table
            role = CheckCustomerCredentials(username, password);

            if (role == null)
            {
                // If not found in Customers table, check the Admins table
                role = CheckAdminCredentials(username, password);
            }

            return role;
        }

        private string CheckCustomerCredentials(string username, string password)
        {
            string role = null;

            // Query to get the password for the customer
            string query = "SELECT Password FROM Customers WHERE Username = @Username";
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = reader["Password"].ToString();
                    if (password == storedPassword)
                    {
                        role = "Customer"; // Return Customer role
                    }
                }
            }

            return role;
        }

        private string CheckAdminCredentials(string username, string password)
        {
            string role = null;

            // Query to get the password for the admin
            string query = "SELECT Password FROM Admins WHERE Username = @Username";
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = reader["Password"].ToString();
                    if (password == storedPassword) 
                    {
                        role = "Admin"; // Return Admin role
                    }
                }
            }

            return role;
        }
       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccountForm = new CreateAccountForm();
            createAccountForm.Show();
            this.Hide();
        }
    }
}
