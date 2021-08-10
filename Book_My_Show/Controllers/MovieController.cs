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
        public string Post(FileUpload fileObj)
        {
            Movie oMovie = JsonConvert.DeserializeObject<Movie>(fileObj.Movie);
            if(fileObj.CoverPhoto.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.CoverPhoto.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oMovie.CoverPhoto = fileBytes;
                }
            }
            if(fileObj.ThemePhoto.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileObj.ThemePhoto.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oMovie.ThemePhoto = fileBytes;
                    oMovie = _movieServices.Add(oMovie);
                    if (oMovie.Id > 0)
                    {
                        return "Movie Saved Successfully";
                    }
                }
            }
            return "Entry Failed.";
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var movie = _movieServices.Get(id);
            movie.ThemePhoto = _movieServices.GetImage(Convert.ToBase64String(movie.ThemePhoto));
            movie.CoverPhoto = _movieServices.GetImage(Convert.ToBase64String(movie.CoverPhoto));
            return new JsonResult(movie);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var moviesList = _movieServices.GetAll();
            foreach(Movie movie in moviesList)
            {
                movie.ThemePhoto = _movieServices.GetImage(Convert.ToBase64String(movie.ThemePhoto));
                movie.CoverPhoto = _movieServices.GetImage(Convert.ToBase64String(movie.CoverPhoto));
            }
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
