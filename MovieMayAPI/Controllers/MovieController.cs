using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMayDL;
using MovieMayDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        //Data Layer
        public MovieDL mdl = new MovieDL();

        // GET: api/<MovieController>/MovieList
        [Route("[action]")]
        [HttpGet]
        public List<Movie> MovieList()
        {
            List<Movie> movielist = mdl.MovieList();
            return movielist;
        }

        // GET api/<MovieController>/MovieById/{id}
        [Route("[action]/{id}")]
        [HttpGet]
        public Movie MovieById(int id)
        {
            Movie movie = mdl.MovieReviewsById(id);
            return movie;
        }

        // POST api/<MovieController>/AddMovie
        [Route("[action]")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public bool AddMovie([FromBody] Movie movie)
        {
            bool res = mdl.MovieAdd(movie);
            return res;
        }
        // POST api/<MovieController>/AddReview
        [Route("[action]")]
        [HttpPost]
        public void AddReview([FromBody] Review review)
        {
            mdl.ReviewAdd(review);
        }
    }
}
