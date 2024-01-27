using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    internal class MovieStorage
    {
        public int ammount;

        public void getAmmount()
        {
            string[] lines = File.ReadAllLines("./data/storage.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public void removeMovie(string title)
        {
            string[] lines = File.ReadAllLines("./data/storage.txt");
            for (int i=0; i<lines.Length; i++)
            {
                string[] strings = lines[i].Split(", ");
                if (strings[0] == title)
                {
                    int currentStorage = int.Parse(strings[1]);
                    int newStorage = currentStorage - 1;

                    strings[1] = " " + newStorage;
                    lines[i] = string.Join(",", strings);
                }                  
            }
            string updatedStorage = string.Join(Environment.NewLine, lines);
            File.WriteAllText("./data/storage.txt", updatedStorage);
        }

        public void addMovie(string title)
        {
            string[] lines = File.ReadAllLines("./data/storage.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] strings = lines[i].Split(", ");
                if (strings[0] == title)
                {
                    int currentStorage = int.Parse(strings[1]);
                    int newStorage = currentStorage + 1;

                    strings[1] = " " + newStorage;
                    lines[i] = string.Join(",", strings);
                }
            }
            string updatedStorage = string.Join(Environment.NewLine, lines);
            File.WriteAllText("./data/storage.txt", updatedStorage);
        }
    }
}
