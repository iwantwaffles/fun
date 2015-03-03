using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMvcSite.Models
{
    public class PostViewModel
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public DateTime DatePosted { get; set; }
        public Comment Comment { get; set; }
    }

    public class CommentViewModel
    {   
        public string Message { get; set; }
    }
}