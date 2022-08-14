using MovieMayDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMay.Models
{
    public class MovieViewModel
    {
        public List<Movie> MovieModel { get; set; }
        public List<Review> ReviewModel { get; set; }
        public Movie MovieDetail { get; set; }
        public Review NewReview { get; set; }
    }
}