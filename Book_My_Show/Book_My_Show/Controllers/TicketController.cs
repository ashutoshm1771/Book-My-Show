using Book_My_Show.Models;
using Book_My_Show.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private ITicketServices _ticketServices;

        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [HttpPost]
        public JsonResult Post(Ticket ticket)
        {
            _ticketServices.Add(ticket);
            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        public JsonResult Get()
        {
            var ticketsList = _ticketServices.Get();
            return new JsonResult(ticketsList);
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var movie = _ticketServices.GetById(id);
            return new JsonResult(movie);
        }

        [HttpGet("userName/{userName}")]
        public JsonResult GetByUserName(string userName)
        {
            var movie = _ticketServices.GetByUserName(userName);
            return new JsonResult(movie);
        }
    }
}
