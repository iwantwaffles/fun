using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.Models
{
    public class PostViewModel
    {
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public MemberViewModel Comment { get; set; }
    }

    public class MemberViewModel
    {
        public string UserName { get; set; }
    }
}