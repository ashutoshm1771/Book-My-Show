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
    public class SeatController : ControllerBase
    {
        private ISeatService _seatServices;

        public SeatController(ISeatService seatServices)
        {
            _seatServices = seatServices;
        }

        [HttpPost]
        public JsonResult Post(Seat seat)
        {
            _seatServices.Add(seat);
            return new JsonResult("Added Successfully");
        }

        [HttpGet]
        public JsonResult Get()
        {
            var seatsList = _seatServices.Get();
            return new JsonResult(seatsList);
        }

        [HttpGet("showTime/{ShowTime}/movie/{MovieId}/theatre/{TheatreId}")]
        public JsonResult GetByMovieAndTheatre(string ShowTime,int MovieId, int TheatreId)
        {
            var movie = _seatServices.GetByShow(ShowTime, TheatreId, MovieId);
            return new JsonResult(movie);
        }

        [HttpPut("ticket/{ticketId}")]
        public JsonResult Put([FromRoute()] int ticketId, [FromBody()]Seat seat)
        {
            _seatServices.ChangeAvailability(ticketId,seat);
            return new JsonResult("Updated Successfully");
        }

    }
}
