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
    public class Data
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
                Parkings=new List<Parking>();
            }

        }
    }
}
