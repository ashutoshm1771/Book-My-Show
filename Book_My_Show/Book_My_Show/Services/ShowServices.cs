using Book_My_Show.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Services
{
    public class ShowServices : IShowServices
    {
        private IDbConnection _db;

        public ShowServices(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public void Add(Show show)
        {
            var sqlQuery = "INSERT INTO Show (Time,TheatreId,MovieId) VALUES (@Time,@TheatreId,@MovieId)";
            _db.Execute(sqlQuery, show);
        }

        public List<Movie> GetByMovieAndCity(string MovieName,string City)
        {
            var queryMovieName = (MovieName == "-1") ? null : MovieName;
            var queryCity = (City == "-1") ? null : City;
            var sqlQuery = "SELECT distinct m.Id,m.Name,m.ImbdRating,m.Category,m.Genre,m.ReleaseDate,m.ActorName,m.ActressName,m.ThemePhotoPath FROM ( Show s join Theatre t on s.TheatreId = t.Id ) join Movies m on m.Id = s.MovieId where ( @MovieName is null or m.Name like '%' + @MovieName + '%' ) and ( @City is null or t.City = @City ) ";
            return _db.Query<Movie>(sqlQuery, new { @MovieName = queryMovieName, @City = queryCity }).ToList();
        }

        public List<ShowMovieModel> GetShowByMovieAndCity(string MovieId, string City)
        {
            var queryCity = (City == "-1") ? null : City;
            var sqlQuery = "SELECT distinct s.Time,s.TheatreId,s.MovieId,t.Name FROM ( Show s join Theatre t on s.TheatreId = t.Id ) join Movies m on m.Id = s.MovieId where ( @MovieId is null or m.Id = @MovieId ) and ( @City is null or t.City = @City ) ";
            return _db.Query<ShowMovieModel>(sqlQuery, new { @MovieId = MovieId, @City = queryCity }).ToList();
        }

        public Show GetByMovieAndTheatre(int MovieId, int TheatreId)
        {
            var sqlQuery = "SELECT * FROM Show where MovieId = @MovieId and TheatreId = @TheatreId";
            return _db.Query<Show>(sqlQuery, new { @MovieId = MovieId , @TheatreId = TheatreId }).SingleOrDefault();
        }

        public List<Show> GetByMovieId(int Id)
        {
            var sqlQuery = "SELECT * FROM Show where MovieId = @MovieId";
            return _db.Query<Show>(sqlQuery, new { @MovieId = Id }).ToList();
        }

        public List<Show> GetByTheatreId(int Id)
        {
            var sqlQuery = "SELECT * FROM Show where TheatreId = @TheatreId";
            return _db.Query<Show>(sqlQuery, new { TheatreId = Id }).ToList();
        }
    }
}
