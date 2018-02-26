using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreAssessment.Models
{

    /// <summary>
    /// This class creates a post with 6 variables , Post ID, PostDate, Title, Username, Description and Comments
    /// </summary>
    public class Post

    {
        [Key]
        public int PostID { get; set; }

        public string UserName { get; set; }

        public string PostTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string PostDesc { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; } = DateTime.Now;

        public virtual List<Comment> Comments { get; set; }

    }
}