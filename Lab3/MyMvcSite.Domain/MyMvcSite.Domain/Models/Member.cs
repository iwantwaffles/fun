﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcSite.Domain.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}