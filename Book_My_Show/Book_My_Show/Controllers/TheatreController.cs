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
    
    public class TheatreController : ControllerBase
    {
    
        private ITheatreServices _theatreServices;

        public TheatreController(ITheatreServices theatreServices)
        {
            _theatreServices = theatreServices;
        }

        [HttpPost]
        public JsonResult Post(Theatre theatre)
        {
            _theatreServices.Add(theatre);
            return new JsonResult("Added Successfully");
        }

        [HttpGet("getById/{id}")]
        public JsonResult Get(int id)
        {
            var movie = _theatreServices.GetById(id);
            return new JsonResult(movie);
        }

        [HttpGet("getByCity/{city}")]
        public JsonResult Get(string city)
        {
            var movie = _theatreServices.GetByCity(city);
            return new JsonResult(movie);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var moviesList = _theatreServices.GetAll();
            return new JsonResult(moviesList);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _theatreServices.Delete(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
