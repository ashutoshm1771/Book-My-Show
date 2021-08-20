using Book_My_Show.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Services
{
    public interface ISeatService
    {
        public void Add(Seat seat);

        public void ChangeAvailability(int ticketId,Seat seat);

        public List<Seat> Get();

        public List<Seat> GetByShow(string ShowTime,int theatreId,int MovieId);
    }
}
