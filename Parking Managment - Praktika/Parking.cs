using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Managment___Praktika
{
    public class Parking
    {
        public string ParkingID { get; set; }
        private string loc;
        public int TotalSpaces { get; set; }
        public int AvailableSpaces { get; set; }
        public List<string> Vehicles { get; set; }

        public string Location
        {
            get { return loc; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new InvalidDataException("Невалидна локация.");
                loc = value;
            }
        }
        public Parking()
        {
            Vehicles = new List<string>();
        }
        public Parking(string location, int totalSpaces)
        {
            ParkingID = Guid.NewGuid().ToString();
            Location = location;
            TotalSpaces = totalSpaces;
            AvailableSpaces = totalSpaces;
            Vehicles = new List<string>();
        }
    }
}
