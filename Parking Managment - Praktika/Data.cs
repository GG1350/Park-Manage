using Microsoft.VisualBasic;
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
    internal class Data
    {
        public List<Parking> Parkings { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadParkings();
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter("D:/G. Zahariev/Parkings.txt");
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(Parkings);
                writer.Write(jsonData);
            }
        }

        public void LoadParkings()
        {
            reader = new StreamReader("D:/G. Zahariev/Parkings.txt");
            using (reader)
            {
                string jsonData = reader.ReadToEnd();
                Parkings = JsonSerializer.Deserialize<List<Parking>>(jsonData)!;
            }
            Parkings ??= new List<Parking>();
        }
    }
}
