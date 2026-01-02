using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class FileHelper
    {
        private readonly string file = "record.txt";
        public void Save(int score, int level)
        {
            using (StreamWriter writer = new StreamWriter(file, false))
            {
                writer.WriteLine($"{score},{level}");
            }
        }

        public List<string> Load()
        {
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(file))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    list.Add(parts[0]);
                    list.Add(parts[1]);
                }

                return list;
            }
        }
    }
}
