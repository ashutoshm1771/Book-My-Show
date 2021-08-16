using Book_My_Show.Models;
using Book_My_Show.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Book_My_Show.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieServices _movieServices;

        public MovieController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpPost]
        public JsonResult Post(Movie movie)
        {
            _movieServices.Add(movie);
            return new JsonResult("Added Successfully");
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var movie = _movieServices.Get(id);
            return new JsonResult(movie);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var moviesList = _movieServices.GetAll();
            return new JsonResult(moviesList);
        }

        [HttpGet("{category}")]
        public JsonResult Get(MovieCategory category)
        {
            var movie = _movieServices.GetByCategory(category);
            return new JsonResult(movie);
        }

        [HttpGet("{genre}")]
        public JsonResult Get(MovieGenre genre)
        {
            var movie = _movieServices.GetByGenre(genre);
            return new JsonResult(movie);
        }

        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            var movie = _movieServices.GetByName(name);
            return new JsonResult(movie);
        }

        [HttpGet("{actorName,actressName}")]
        public JsonResult GetByStarNames(string actorName,string actressName)
        {
            var movie = _movieServices.GetByStarNames(actorName,actressName);
            return new JsonResult(movie);
        }

        [HttpPut]
        public JsonResult Put(Movie movie)
        {
            _movieServices.Update(movie);
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _movieServices.Delete(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
