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

        [HttpGet("movie/{MovieId}")]
        public JsonResult GetyMovieId(int MovieId)
        {
            var show = _showServices.GetByMovieId(MovieId);
            return new JsonResult(show);
        }

        [HttpGet("theatre/{TheatreId}")]
        public JsonResult GetByTheatreId(int TheatreId)
        {
            var movie = _showServices.GetByMovieId(TheatreId);
            return new JsonResult(movie);
        }

        [HttpGet("movie/{MovieId}/theatre/{TheatreId}")]
        public JsonResult GetByMovieAndTheatre(int MovieId,int TheatreId)
        {
            var movie = _showServices.GetByMovieAndTheatre(MovieId,TheatreId);
            return new JsonResult(movie);
        }

        [HttpGet("movieName/{MovieName}/city/{City}")]
        public JsonResult GetByMovieAndCity(string MovieName,string City)
        {
            var movie = _showServices.GetByMovieAndCity(MovieName,City);
            return new JsonResult(movie);
        }

        [HttpGet("movie/{MovieId}/city/{City}")]
        public JsonResult GetShowByMovieAndCity(string MovieId, string City)
        {
            var movie = _showServices.GetShowByMovieAndCity(MovieId, City);
            return new JsonResult(movie);
        }
    }
}
