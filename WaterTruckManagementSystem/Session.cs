using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTruckManagementSystem
{
    internal class Session
    {
        public static string Username { get; set; }
        public static int CustomerID { get; set; } // Optional if you fetch it during login
    }
}
