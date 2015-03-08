using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.Models
{
    public class Forum
    {
        public int ForumID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}