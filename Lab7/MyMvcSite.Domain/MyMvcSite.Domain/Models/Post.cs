﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.Models
{
    public class Post : IEntityModels
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Body { get; set; }
        public string MemberID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }

        
    }
}