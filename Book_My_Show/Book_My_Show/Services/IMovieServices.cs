using Book_My_Show.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Services
{
    public interface IMovieServices
    {
        public Movie Add(Movie movie);
        
        public Movie Get(int id);

        public void Update(Movie movie);
        
        public void Delete(int id);

        public List<Movie> GetAll();

        public List<Movie> GetByCategory(MovieCategory Category);

        public List<Movie> GetByName(string Name);

        public List<Movie> GetByStarNames(string ActorName, string ActressName);

        public List<Movie> GetByGenre(MovieGenre Genre); 
    }
}
