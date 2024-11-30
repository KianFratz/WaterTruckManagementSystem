using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterTruckManagementSystem.userController
{
    public partial class UserControl2 : UserControl
    {
        double barrelContainer = 60;
        double gallonContainer = 10;
        double tankContainer = 500;
        public UserControl2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            // Ensure the quantity is a valid number
            double quantity;
            if (double.TryParse(txtQuantity.Text, out quantity))
            {
                double totalPrice = 0;

                if (cmbWaterContainer.Text == "Barrel")
                {
                    totalPrice = barrelContainer * quantity;
                }
                else if (cmbWaterContainer.Text == "Gallon")
                {
                    totalPrice = gallonContainer * quantity;
                }
                else if (cmbWaterContainer.Text == "Tank")
                {
                    totalPrice = tankContainer * quantity;
                }
                else
                {
                    // If no container is selected, clear total price or show an error
                    txtTotalPrice.Clear();
                    return;
                }

                // Update the total price text box
                txtTotalPrice.Text = totalPrice.ToString("F2");  // Format to 2 decimal places
            }
            else
            {
                // Show an error if the quantity is invalid
                MessageBox.Show("Please enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
