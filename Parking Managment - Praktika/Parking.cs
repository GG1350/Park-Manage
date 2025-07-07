using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Managment___Praktika
{
    public class Parking
    {
        public string ParkingID {  get; set; }
        private string loc;
        private int totalSpaces;
        public int AvailableSpaces;
        public string Vehicles;
        
        public string Location
        {
            get { return loc; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new InvalidDataException("Невалидна локация.");
                }
                loc = value;
            }
        }
        public int TotalSpaces
        {
            get { return totalSpaces; }
            set
            {
                if (value < 10)
                {
                    throw new InvalidDataException("Паркингът трябва да има поне 10 места");
                }
                totalSpaces = value;
            }
        }

        public Parking(string loc,int totalSpaces)
        {
            ParkingID=Guid.NewGuid().ToString();
            Location = loc;
            TotalSpaces = totalSpaces;
            AvailableSpaces = totalSpaces;
            Vehicles = "";
        }
    }
}
