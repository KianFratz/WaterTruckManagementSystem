using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterTruckManagementSystem
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;  
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get form inputs
            string username = txtUsername.Text.Trim();
            string address = txtAddress.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(address) ||
                string.IsNullOrEmpty(contactNumber) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsContactNumberValid(contactNumber))
            {
                MessageBox.Show("Contact number must be numeric and 10-15 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsUsernameUnique(username))
            {
                MessageBox.Show("The username is already taken. Please choose another one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save 
            SaveCustomerToDatabase(username, address, contactNumber, password);

            MessageBox.Show("Customer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear fields
            txtUsername.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtUsername.Focus();
        }

        //Contact Number Validation
        private bool IsContactNumberValid(string contactNumber)
        {
            return contactNumber.All(char.IsDigit) && contactNumber.Length >= 10 && contactNumber.Length <= 15;
        }

        // Username Uniqueness Check
        private bool IsUsernameUnique(string username)
        {
            bool isUnique = false;

            string query = "SELECT COUNT(*) FROM Customers WHERE Username = @Username";
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                isUnique = count == 0;
            }

            return isUnique;
        }

        // Saving Customer to Database
        private void SaveCustomerToDatabase(string username, string address, string contactNumber, string password)
        {
            string query = "INSERT INTO Customers (Username, Address, ContactNumber, Password) VALUES (@Username, @Address, @ContactNumber, @Password)";
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SOQDMF7;Initial Catalog=WaterTruck;Integrated Security=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
