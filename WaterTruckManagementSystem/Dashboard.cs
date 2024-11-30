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
    public partial class Dashboard : Form
    {
        NavigationControl navigationControl;
        public Dashboard()
        {
            InitializeComponent();
            InitializeNavigationControl();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>()
            {
                new UserControl1(), new UserControl2(), new UserControl3(), new UserControl4()
            };

            navigationControl = new NavigationControl(userControls, panel2);
            navigationControl.DisplayPanel(0);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            navigationControl.DisplayPanel(0);
        }

        private void btnMOrder_Click(object sender, EventArgs e)
        {
            navigationControl.DisplayPanel(1);
        }

        private void btnHistory_Click_1(object sender, EventArgs e)
        {
            navigationControl.DisplayPanel(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
