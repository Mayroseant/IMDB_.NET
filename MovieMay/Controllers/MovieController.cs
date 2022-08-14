using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMay.Models;
using MovieMayDL;
using MovieMayDL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMay.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        //Data Layer
        public MovieDL mdl = new MovieDL();
        //Home
        public IActionResult Index()
        {
            MovieViewModel movie = new MovieViewModel();
            movie.MovieModel = mdl.MovieList();
            return View(movie);
        }
        //Add new movie
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie([Bind] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Data entered are not of the right format!";
                return View();
            }
            bool res = mdl.MovieAdd(movie);
            if(res == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "This movie already exists!";
                return View();
            }
        }
        public IActionResult MovieDetails(int id)
        {
            MovieViewModel movie = new MovieViewModel();
            movie.MovieDetail = mdl.MovieById(id);
            movie.ReviewModel = mdl.ReviewById(id);

            return View(movie);
        }
        [HttpPost]
        public IActionResult AddReview(MovieViewModel movieViewModel)
        {
            mdl.ReviewAdd(movieViewModel.NewReview);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddReview1(MovieViewModel movieViewModel)
        {
            var id = movieViewModel.NewReview.MovieId;
            mdl.ReviewAdd(movieViewModel.NewReview);
            return RedirectToAction("MovieDetails", new { id = id });
        }
    }
}
