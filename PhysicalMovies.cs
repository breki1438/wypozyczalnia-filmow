using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    internal class PhysicalMovies : Movies
    {
        public string type;
        public string distribution;
        public string condition;
        public static List<Movies> getPhysicalMovies()
        {

            List<Movies> moviesList = new List<Movies>();
            string[] lines = File.ReadAllLines("./data/movieInfo.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                PhysicalMovies movie = new PhysicalMovies
                {
                    title = data[0].Trim(),
                    director = data[1].Trim(),
                    year = int.Parse(data[2].Trim()),
                    genre = data[3].Trim(),
                    price = int.Parse(data[4].Trim()),
                    type = data[5].Trim(),
                    distribution = data[6].Trim(),
                    condition = data[7].Trim()
                };
                if (movie.type == "plytka")
                    moviesList.Add(movie);
            }

            return moviesList;
        }

        public void getAllPhysicallMovies()
        {
            foreach (PhysicalMovies movie in getPhysicalMovies())
                Console.WriteLine(movie.title + " " + movie.distribution + " " + movie.director + " " + movie.year + " " + movie.genre + " " + movie.price + " " + movie.condition);
        }

        public void getPhysicalMovie(string title)
        {
            foreach (PhysicalMovies movie in getPhysicalMovies())
                if (movie.title == title)
                    Console.WriteLine(movie.title + " " + " " + movie.distribution + " " + movie.director + " " + movie.year + " " + movie.genre + " " + movie.price + " " + movie.condition);
        }
    }
}
