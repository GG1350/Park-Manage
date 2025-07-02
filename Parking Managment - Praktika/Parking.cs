using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Managment___Praktika
{
    internal class Parking
    {
        public int ParkingID { get; set; }

        public string Loc { get; set; }
        
        public int TotalSpaces { get; set; }

        public int AvailableSpaces { get; set; }

        public string Vehicles { get; set; }

        public Parking(string loc,int totalSpaces)
        {
            Loc = loc;
            TotalSpaces = totalSpaces;
            AvailableSpaces = totalSpaces;
        }
    }
}
