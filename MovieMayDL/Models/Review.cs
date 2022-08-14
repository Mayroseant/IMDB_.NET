using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MovieMayDL.Models
{
    public partial class Review
    {
        public int RId { get; set; }
        [StringLength(200, ErrorMessage = "It cant be more than 200 characters!")]
        public string Comment { get; set; }
        public DateTime? PostDatetime { get; set; }
        public int? MovieId { get; set; }
        public string Mail { get; set; }

        public virtual User MailNavigation { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
