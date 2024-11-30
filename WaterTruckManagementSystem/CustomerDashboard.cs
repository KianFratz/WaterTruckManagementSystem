using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterTruckManagementSystem.userController;
using WaterTruckManagementSystem.UserControls;

namespace WaterTruckManagementSystem
{
    public partial class CustomerDashboard : Form
    {
        NavigationControlCustomer navigationControlCustomer;
        
        public CustomerDashboard()
        {
            InitializeComponent();
            InitializeNavigationControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void InitializeNavigationControl()
        {
            List<UserControl> customerControls = new List<UserControl>() // UserControll list
            {
                new CustomerControl1(), new CustomerControl2(), new CustomerControl3(), new CustomerControl4()
            };

            navigationControlCustomer = new NavigationControlCustomer(customerControls, panel2);
            navigationControlCustomer.DisplayPanel(0);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            navigationControlCustomer.DisplayPanel(0);
        }

        private void btnBuyOrder_Click(object sender, EventArgs e)
        {
            navigationControlCustomer.DisplayPanel(1);
        }

        private void btnYourOrder_Click(object sender, EventArgs e)
        {
            navigationControlCustomer.DisplayPanel(2);
            
            
        }

       

        private void btnHistory_Click(object sender, EventArgs e)
        {
            navigationControlCustomer.DisplayPanel(3);
        }

        private void label2_Click(object sender, EventArgs e)
        {           
            //lblCustomerName.Text = Session.Username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string username = Session.Username.ToLower();
            lblCustomerName.Text = char.ToUpper(username[0]) + username.Substring(1);
        }
    }
}
