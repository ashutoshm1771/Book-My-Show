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
    public class TicketServices : ITicketServices
    {
        private IDbConnection _db;
        public TicketServices(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(Ticket ticket)
        {
            var sqlQuery = "INSERT INTO Ticket (UserName,NumberOfSeats,ShowTime,TheatreId,MovieId) VALUES (@UserName,@NumberOfSeats,@ShowTime,@TheatreId,@MovieId)";
            _db.Execute(sqlQuery, ticket);
        }

        public List<Ticket> Get()
        {
            var sqlQuery = "SELECT * FROM Ticket";
            return _db.Query<Ticket>(sqlQuery).ToList();
        }

        public Ticket GetById(int id)
        {
            var sqlQuery = "SELECT * FROM Ticket where Id = @id";
            return _db.Query<Ticket>(sqlQuery, new { @Id = id }).Single();
        }

        public Ticket GetByUserName(string UserName)
        {
            var sqlQuery = "SELECT * FROM Ticket where UserName = @UserName";
            return _db.Query<Ticket>(sqlQuery, new { @UserName = UserName }).SingleOrDefault();
        }
    }
}
