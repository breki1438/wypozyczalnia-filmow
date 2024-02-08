using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow
{
    public class Movies
    {
        public string title;
        public string director;
        public int year;
        public string genre;
        public int price;

        public static List<Movies> getMovies()
        {
            List<Movies> moviesList = new List<Movies>();
            string[] lines = File.ReadAllLines("./data/movieInfo.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                Movies movie = new Movies
                {
                    title = data[0].Trim(),
                    director = data[1].Trim(),
                    year = int.Parse(data[2].Trim()),
                    genre = data[3].Trim(),
                };

                    moviesList.Add(movie);
                }

            return moviesList;
        }

        public void getAllMovies()
        {
            foreach (Movies movie in getMovies())
                Console.WriteLine(movie.title + " " + movie.director + " " + movie.year + " " + movie.genre);
        }

        public void getMovie(string title)
        {
            foreach (Movies movie in getMovies())
                if(movie.title == title)
                    Console.WriteLine(movie.title + " " + movie.director + " " + movie.year + " " + movie.genre);             
        }
    }
}
