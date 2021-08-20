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
    public class TheatreServices : ITheatreServices
    {
        private IDbConnection _db;

        public TheatreServices(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(Theatre theatre)
        {
            var sqlQuery = "INSERT INTO Theatre (Name,City) VALUES (@Name,@City)";
            _db.Execute(sqlQuery, theatre);
        }

        public void Delete(int Id)
        {
            var sqlQuery = "DELETE FROM Theatre where Id = @Id";
            _db.Execute(sqlQuery, new { Id });
        }

        public List<Theatre> GetAll()
        {
            var sqlQuery = "SELECT * FROM Theatre";
            return _db.Query<Theatre>(sqlQuery).ToList();
        }

        public List<Theatre> GetByCity(string City)
        {
            var sqlQuery = "SELECT * FROM Theatre where City = @City";
            return _db.Query<Theatre>(sqlQuery, new { @City = City }).ToList();
        }

        public Theatre GetById(int Id)
        {
            var sqlQuery = "SELECT * FROM Theatre where Id = @Id";
            return _db.Query<Theatre>(sqlQuery, new { @Id = Id }).SingleOrDefault();
        }
    }
}
