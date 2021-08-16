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
    public class ShowController : ControllerBase
    {

        private IShowServices _showServices;

        public ShowController(IShowServices showServices)
        {
            _showServices = showServices;
        }

        [HttpPost]
        public JsonResult Post(Show show)
        {
            _showServices.Add(show);
            return new JsonResult("Added Successfully");
        }

        [HttpGet("getByMovieId/{MovieId}")]
        public JsonResult GetyMovieId(int MovieId)
        {
            var movie = _showServices.GetByMovieId(MovieId);
            return new JsonResult(movie);
        }

        [HttpGet("getByTheatreId/{TheatreId}")]
        public JsonResult GetByTheatreId(int TheatreId)
        {
            var movie = _showServices.GetByMovieId(TheatreId);
            return new JsonResult(movie);
        }

        [HttpGet("getByMovieAndTheatre/{MovieId}/{TheatreId}")]
        public JsonResult GetByMovieAndTheatre(int MovieId,int TheatreId)
        {
            var movie = _showServices.GetByMovieAndTheatre(MovieId,TheatreId);
            return new JsonResult(movie);
        }

        [HttpGet("getByMovieAndCity/{MovieName}/{City}")]
        public JsonResult GetByMovieAndCity(string MovieName,string City)
        {
            var movie = _showServices.GetByMovieAndCity(MovieName,City);
            return new JsonResult(movie);
        }
    }
}
