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
        public List<Book> Books { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadBooks();
        }

        public void Save()
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(Books);
                writer.Write(jsonData);
            }
        }

        public void LoadBooks()
        {
            reader = new StreamReader(filePath);
            using (reader)
            {
                string jsonData = reader.ReadToEnd();
                Books = JsonSerializer.Deserialize<List<Book>>(jsonData)!;
            }
            Books ??= new List<Book>();
        }
    }
}
