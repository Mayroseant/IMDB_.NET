using System;
using System.Collections.Generic;

#nullable disable

namespace MovieMayDL.Models
{
    public partial class User
    {
        public User()
        {
            Reviews = new HashSet<Review>();
        }

        public string Email { get; set; }
        public string UserRole { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
