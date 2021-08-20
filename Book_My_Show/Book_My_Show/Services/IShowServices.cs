using Book_My_Show.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Services
{
    public interface IShowServices
    {
        public void Add(Show show);

        public List<Show> GetByTheatreId(int Id);

        public List<Show> GetByMovieId(int Id);

        public List<Movie> GetByMovieAndCity(string MovieName, string City);

        public List<ShowMovieModel> GetShowByMovieAndCity(string MovieName, string City);

        public Show GetByMovieAndTheatre(int MovieId, int TheatreId);

    }
}
