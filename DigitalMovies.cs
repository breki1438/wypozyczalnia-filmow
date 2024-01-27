using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    internal class DigitalMovies : Movies
    {
        public string type;
        public string distribution;

        public static List<Movies> getDigitalMovies()
        {

            List<Movies> moviesList = new List<Movies>();
            string[] lines = File.ReadAllLines("./data/movieInfo.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                DigitalMovies movie = new DigitalMovies
                {
                    title = data[0].Trim(),
                    director = data[1].Trim(),
                    year = int.Parse(data[2].Trim()),
                    genre = data[3].Trim(),
                    price = int.Parse(data[4].Trim()),
                    type = data[5].Trim(),
                    distribution = data[6].Trim()
                };
                if (movie.type == "cyfrowy")
                    moviesList.Add(movie);
            }

            return moviesList;
        }

        public void getAllDigitalMovies()
        {
            foreach (DigitalMovies movie in getDigitalMovies())
                Console.WriteLine(movie.title + " " + movie.distribution + " " + movie.director + " " + movie.year + " " + movie.genre + " " + movie.price);
        }

        public void getDigitalMovie(string title)
        {
            foreach (DigitalMovies movie in getDigitalMovies())
                if (movie.title == title)
                    Console.WriteLine(movie.title + " " + " " + movie.distribution + " " + movie.director + " " + movie.year + " " + movie.genre + " " + movie.price);
        }
    }
}
