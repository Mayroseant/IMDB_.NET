using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MovieMayDL.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Reviews = new HashSet<Review>();
        }

        public int MId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Genre { get; set; }
        [StringLength(100)]
        public string Director { get; set; }
        [StringLength(500)]
        public string Starring { get; set; }
        [StringLength(500)]
        public string Producer { get; set; }
        public string Watchtime { get; set; }
        public string Release { get; set; }
        [StringLength(500)]
        public string About { get; set; }
        public string Rating { get; set; }
        [StringLength(500)]
        [Url]
        public string Poster { get; set; }
        [StringLength(500)]
        [Url]
        public string Trailer { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
