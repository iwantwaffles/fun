using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.Models
{
    public class Topic : IEntityModels
    {
        public int ID { get; set; }
        public int TopicID { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Member { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}