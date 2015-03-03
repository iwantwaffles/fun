using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMvcSite.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public DateTime DatePosted { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}