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
    public class MovieServices : IMovieServices
    {

        private IDbConnection _db;
        public MovieServices(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Movie Add(Movie movie)
        {
            var sqlQuery = "INSERT INTO Movies (Name,ImbdRating,Category,Genre,ReleaseDate,ActorName,ActressName,ThemePhotoPath) VALUES (@Name,@ImbdRating,@Category,@Genre,@ReleaseDate,@ActorName,@ActressName,@ThemePhotoPath)";
            _db.Execute(sqlQuery, movie);
            return movie;
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Movies where Id = @id";
            _db.Execute(sqlQuery, new { id });
        }

        public Movie Get(int id)
        {
            var sqlQuery = "SELECT * FROM Movies where Id = @id";
            return _db.Query<Movie>(sqlQuery, new { @Id = id }).Single();
        }

        public List<Movie> GetAll()
        {
            var sqlQuery = "SELECT * FROM Movies";
            return _db.Query<Movie>(sqlQuery).ToList();
        }

        public List<Movie> GetByCategory(MovieCategory Category)
        {
            var sqlQuery = "SELECT * FROM Movies where Category = @Category";
            return _db.Query<Movie>(sqlQuery, new { @Category = Category }).ToList();
        }

        public List<Movie> GetByGenre(MovieGenre Genre)
        {
            var sqlQuery = "SELECT * FROM Movie where Genre = @Genre";
            return _db.Query<Movie>(sqlQuery, new { @Genre = Genre }).ToList();
        }

        public List<Movie> GetByName(string Name)
        {
            var sqlQuery = "SELECT * FROM Movies where Name like @Name";
            return _db.Query<Movie>(sqlQuery, new { @Name = Name }).ToList();
        }

        public List<Movie> GetByStarNames(string ActorName, string ActressName)
        {
            var sqlQuery = "SELECT * FROM Movies where ActorName like @ActorName and ActressName like @ActressName";
            return _db.Query<Movie>(sqlQuery, new { @ActorName = ActorName , @ActressName = ActressName }).ToList();
        }

        public byte[] GetCoverPhoto(int id)
        {
            var sqlQuery = "SELECT CoverPhoto FROM Movies where Id = @id";
            return _db.Query<byte[]>(sqlQuery, new { @Id = id }).Single();
        }

        public byte[] GetThemePhoto(int id)
        {
            var sqlQuery = "SELECT ThemePhoto FROM Movies where Id = @id";
            return _db.Query<byte[]>(sqlQuery, new { @Id = id }).Single();
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if( !string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }

        public void Update(Movie movie)
        {
            var sqlQuery = "UPDATE Movies SET Name = @Name, ImbdRating = @ImbdRating, Category = @Category, Genre = @Genre, ReleaseDate = @ReleaseDate, ActorName = @ActorName, ActressName = @ActressName, CoverPhoto = @CoverPhoto, ThemePhoto = @ThemePhoto where Id = @Id";
            _db.Execute(sqlQuery, movie);
        }
    }
}
