﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterTruckManagementSystem
{
    public class NavigationControl
    {  
        List<UserControl> userControlList = new List<UserControl> ();
        Panel panel;

        public NavigationControl(List<UserControl> userControlList, Panel panel)
        {
            this.userControlList = userControlList;
            this.panel = panel;
            AddUserControls();
        }

        

        internal void DisplayPanel(int index)
        {
            if (index < userControlList.Count())
            {
                userControlList[index].BringToFront();
            }

            //throw new NotImplementedException();
        }

        private void AddUserControls()
        {
            for (int i = 0; i < userControlList.Count(); i++)
            {
                userControlList[i].Dock = DockStyle.Fill;
                panel.Controls.Add(userControlList[i]);
            }
        }
    }
}
