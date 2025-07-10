using Microsoft.VisualBasic;
using Parking_Managment___Praktika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Parking_Managment___Praktika
{
    using System.Text.Json;
    using static Constants;
    public class Data
    {
        private int lastUsedId = 1;

        public List<Parking> Parkings { get; private set; }
        public List<Parking> park = new List<Parking>();
        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadParkings();
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(Parkings);
                writer.Write(jsonData);
            }
        }

        public void LoadParkings()
        {
            Parkings = new List<Parking>();
            try
            {
                reader = new StreamReader(filePath);
                using (reader)
                {
                    string jsonData = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonData))
                    {

                        Parkings = JsonSerializer.Deserialize<List<Parking>>(jsonData)!;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Parkings = new List<Parking>();
            }

        }
        public List<Parking> GetAvailableParkings()
        {
            foreach (var p in Parkings)
            {
                if (p.AvailableSpaces != 0)
                {
                    park.Add(p);
                }
            }
            return park;
        }
        public bool RemoveParking(string parkingID)
        {
            Parking parkingToRemove = Parkings.FirstOrDefault(p => p.ParkingID == parkingID);

            if (parkingToRemove != null)
            {
                Parkings.Remove(parkingToRemove);
                Save();

                return true; // success
            }

            return false; // not found
        }
    }
        
}

