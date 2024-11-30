using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterTruckManagementSystem
{
    internal class NavigationControlCustomer
    {
        List<UserControl> customerControlList = new List<UserControl>();
        Panel panel;

        public NavigationControlCustomer(List<UserControl> customerControlList, Panel panel)
        {
            this.customerControlList = customerControlList;
            this.panel = panel;
            AddCustomerControls();
        }

        public void DisplayPanel(int index)
        {
            if (index < customerControlList.Count())
            {
                customerControlList[index].BringToFront();
            }

            //throw new NotImplementedException();
        }

        private void AddCustomerControls()
        {
            for (int i = 0; i < customerControlList.Count(); i++)
            {
                customerControlList[i].Dock = DockStyle.Fill;
                panel.Controls.Add(customerControlList[i]);
            }
        }
    }
}
