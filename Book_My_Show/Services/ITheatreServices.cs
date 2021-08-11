using Book_My_Show.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Services
{
    public interface ITheatreServices
    {
        public void Add(Theatre theatre);

        public Theatre GetById(int Id);

        public List<Theatre> GetByCity(string City);

        public void Delete(int Id);

        public List<Theatre> GetAll();
    }
}
