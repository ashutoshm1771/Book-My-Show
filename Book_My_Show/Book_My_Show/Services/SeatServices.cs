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
    public class SeatServices : ISeatService
    {
        private IDbConnection _db;
        public SeatServices(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Add(Seat seat)
        {
            var sqlQuery = "INSERT INTO Seat (Number,ShowTime,TheatreId,MovieId) VALUES (@Number,@ShowTime,@TheatreId,@MovieId)";
            _db.Execute(sqlQuery, seat);
        }

        public List<Seat> Get()
        {
            var sqlQuery = "SELECT * FROM Seat";
            return _db.Query<Seat>(sqlQuery).ToList();
        }

        public void ChangeAvailability(int ticketId,Seat seat)
        {
            seat.Availability =  (seat.Availability == "Available") ?  "Occupied" : "Available";
            var sqlQuery = "UPDATE Seat SET Number = @Number, ShowTime = @ShowTime, TheatreId = @TheatreId, MovieId = @MovieId,TicketId = @TicketId, Availability = @Availability where Number = @Number and ShowTime = @ShowTime and TheatreId = @TheatreId and MovieId = @MovieId";
            _db.Execute(sqlQuery, new { @Number = seat.Number, @ShowTime = seat.ShowTime, @TheatreId = seat.TheatreId, @MovieId = seat.MovieId, @Availability = seat.Availability, @TicketId = ticketId });
        }

        public List<Seat> GetByShow(string ShowTime,int theatreId,int MovieId)
        {
            var sqlQuery = "SELECT * FROM Seat where ShowTime = @ShowTime and TheatreId = @theatreId and MovieId = @MovieId";
            return _db.Query<Seat>(sqlQuery, new { @ShowTime = ShowTime, @TheatreId = theatreId, @MovieId = MovieId }).ToList();
        }
    }
}
