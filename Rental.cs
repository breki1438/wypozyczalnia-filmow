using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class Rental
    {
        public void addRental(string rentedMovie, string client, DateOnly rentDate, DateOnly returnDate, double rentCost)
        {
            File.AppendAllText("./data/rentalInfo.txt", rentedMovie + ", " + client + ", " + rentDate + ", " + returnDate + ", " + rentCost + "\n");
        }

        public void deleteRental(string rentedMovie, string client)
        {
            string[] file = File.ReadAllLines("./data/rentalInfo.txt");
            var filteredFile = file.Where(line => !line.Contains(rentedMovie) && !line.Contains(client)).ToArray();
            File.WriteAllLines("./data/rentalInfo.txt", filteredFile);
        }

        public void findRentals(string name)
        {
            string[] data = File.ReadAllLines("./data/rentalInfo.txt");
            foreach (string line in data) 
            {
                string[] lines = line.Split(",");
                if (lines[1].Trim() == name)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
