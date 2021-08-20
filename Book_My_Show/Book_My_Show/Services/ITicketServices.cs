using Book_My_Show.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Services
{
    public interface ITicketServices
    {
        public void Add(Ticket ticket);

        public List<Ticket> Get();

        public Ticket GetById(int Id);

        public Ticket GetByUserName(string UserName);
    }
}
