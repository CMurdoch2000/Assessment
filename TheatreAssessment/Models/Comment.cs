using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreAssessment.Models
{
    /// <summary>
    /// This class creates a comment with 5 variables, Post ID, Comment ID , Comment Body, Comment Date and Username
    /// </summary>
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }


        public int PostID { get; set; }

        [DataType(DataType.MultilineText)]
        public string CommentBody { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CommentDate { get; set; } = DateTime.Now;

        public string UserName { get; set; }
    }
}