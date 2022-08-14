using Microsoft.EntityFrameworkCore;
using MovieMayDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMayDL
{
    public class MovieDL
    {
        public MovieMayContext _context = new MovieMayContext();
        public List<Movie> MovieList()
        {
            return _context.Movies.Include(x => x.Reviews).ToList();
        }
        public Movie MovieById(int id)
        {
            Movie moviedetails = _context.Movies.Where(x => x.MId == id).FirstOrDefault();
            return moviedetails;
        }
        //api
        public Movie MovieReviewsById(int id)
        {
            Movie moviereviews = _context.Movies.Where(x => x.MId == id).Include(x => x.Reviews).FirstOrDefault();
            return moviereviews;
        }
        public bool MovieAdd(Movie movie)
        {
            Movie moviedetails = _context.Movies.Where(x => x.Name == movie.Name && x.Director == movie.Director).FirstOrDefault();
            if(moviedetails != null)
            {
                return false;
            }
            else
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return true;
            }
        }
        public void ReviewAdd(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public List<Review> ReviewById(int mid)
        {
            return _context.Reviews.Where(x => x.MovieId == mid).ToList();
        }
    }
}
